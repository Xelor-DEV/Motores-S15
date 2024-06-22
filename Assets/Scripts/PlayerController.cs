using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _compRigidbody;
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float checkdistance;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animatorPlayer;
    private bool isMoving;
    private Vector2 _movement = Vector2.zero;
    private bool _canJump;
    private NPCController currentNPC;
    private void FixedUpdate()
    {
        Vector3 moveDirection = transform.forward * _movement.y + transform.right * _movement.x;
        _compRigidbody.velocity = new Vector3(moveDirection.x * velocity, _compRigidbody.velocity.y, moveDirection.z * velocity);
        _canJump = Physics.Raycast(transform.position,Vector3.down, checkdistance, groundLayer);
        transform.Rotate(0, _movement.x * velocity, 0);
        animatorPlayer.SetFloat("VelocityX", _movement.x);
        animatorPlayer.SetFloat("VelocityY", _movement.y);

    }
    public void Movimiento(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() * velocity;
    }

    private void Update()
    {
        if (_movement.x != 0 || _movement.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (isMoving == true && AudioManagerController.Instance.SfxAudioSource.isPlaying == false)
        {
            AudioManagerController.Instance.SfxAudioSource.clip = AudioManagerController.Instance.SfxClips[0];
            AudioManagerController.Instance.SfxAudioSource.Play();
        }
        else if (isMoving == false && AudioManagerController.Instance.SfxAudioSource.isPlaying == true)
        {
            AudioManagerController.Instance.SfxAudioSource.Stop();
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            if (_canJump == true)
            {
                _compRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            currentNPC = other.GetComponent<NPCController>();
        }
        else if (other.tag == "Portal")
        {
            string sceneToChange = other.GetComponent<PortalController>().SceneName;
            GameManagerController.Instance.ChangeScene(sceneToChange);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            currentNPC = null;
        }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed == true && currentNPC != null && currentNPC.IsPlayerInRange == true)
        {
            InteractProcess();
        }
    }
    public void InteractProcess()
    {
        currentNPC.Interact();
    }
}
