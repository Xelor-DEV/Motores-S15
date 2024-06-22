using System.Collections;
using UnityEngine;
using System;

public class NPCController : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private int currentPointIndex = 0;
    private Rigidbody _compRigidbody;
    private bool isMoving = true;
    [SerializeField] private Animator animatorNPC;
    [SerializeField] private NPCData data;
    private bool isInteracting = false;
    private bool isPlayerInRange = false;
    public static Action<NPCData> dialogueRequested;
    public bool IsPlayerInRange
    {
        get 
        { 
            return isPlayerInRange; 
        }
    }
    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        if (patrolPoints.Length > 0)
        {
            transform.position = patrolPoints[0].position + new Vector3(0.1f, 0, 0);
            transform.LookAt(patrolPoints[currentPointIndex]);
        }
    }
    void FixedUpdate()
    {
        if (patrolPoints.Length != 0 && isMoving == true && isInteracting == false )
        {
            Transform targetPoint = patrolPoints[currentPointIndex];
            Vector3 directionToTarget = (targetPoint.position - transform.position).normalized;
            _compRigidbody.velocity = directionToTarget * data.Speed;
            transform.rotation = Quaternion.LookRotation(directionToTarget);
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex = currentPointIndex + 1;
                }
                else
                {
                    currentPointIndex = 0;
                }
                _compRigidbody.velocity = Vector3.zero;
                StartCoroutine(PauseAtPatrolPoint());
                
            }
            animatorNPC.SetFloat("VelX", _compRigidbody.velocity.x);
            animatorNPC.SetFloat("VelY", _compRigidbody.velocity.z);
        }
    }

    IEnumerator PauseAtPatrolPoint()
    {
        isMoving = false;
        yield return new WaitForSeconds(data.WaitTime);
        isMoving = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(UIManagerController.Instance.DialogueDuration);
        UIManagerController.Instance.Dialogue.SetActive(false);
        isInteracting = false;
        isMoving = true;
        animatorNPC.SetFloat("VelX", 0);
        animatorNPC.SetFloat("VelY", 0);
    }
    public void Interact()
    {
        if (isInteracting == false)
        {
            isInteracting = true;
            isMoving = false;
            animatorNPC.SetFloat("VelX", 0);
            animatorNPC.SetFloat("VelY", 0);
            dialogueRequested?.Invoke(data);
            StartCoroutine(ShowDialogue());
        }
    }
}
