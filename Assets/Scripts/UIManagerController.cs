using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class UIManagerController : MonoBehaviour
{
    public static UIManagerController Instance { get; private set; }
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private TMP_Text nameOfNPC;
    [SerializeField] private TMP_Text message;
    [SerializeField] private float dialogueDuration;
    [Header("FadeControl")]
    [SerializeField] private Image image;
    [SerializeField] private Color startColorIn;
    [SerializeField] private Color targetColorIn;
    [SerializeField] private Color startColorOut;
    [SerializeField] private Color targetColorOut;
    [SerializeField] private float smoothing;
    [Header("TransitionControl")]
    [SerializeField] private float duration;
    [SerializeField] private Ease ease;
    [SerializeField] private float initialY;
    public Image ImageFade
    {
        get
        {
            return image;
        }
        set
        {
            image = value;
        }
    }
    public float DialogueDuration
    {
        get
        {
            return dialogueDuration;
        }
    }
    public TMP_Text NameOfNPC
    {
        get
        {
            return nameOfNPC;
        }
        set
        {
            nameOfNPC = value;
        }
    }
    public TMP_Text Message
    {
        get
        {
            return message;
        }
        set
        {
            message = value;
        }
    }
    public GameObject Menu
    {
        get
        {
            return menu;
        }
        set
        {
            menu = value;
        }
    }
    public GameObject Dialogue
    {
        get
        {
            return dialogue;
        }
        set
        {
            dialogue = value;
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void ActivateMenu()
    {
        menu.GetComponent<RectTransform>().DOAnchorPosY(0, duration).SetEase(ease);
    }
    public void DisableMenu()
    {
        menu.GetComponent<RectTransform>().DOAnchorPosY(initialY, duration).SetEase(ease);
    }
    public void ShowDialogueInCanvas(NPCData npc)
    {
        dialogue.SetActive(true);
        nameOfNPC.text = npc.name;
        message.text = npc.Message;
    }
    public void StartFade()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        float alpha = 0f;
        while (alpha <= 1)
        {
            Color currentColor = Color.Lerp(startColorOut, targetColorOut, alpha);
            image.color = currentColor;
            yield return new WaitForSeconds(smoothing);
            alpha += 0.1f;
        }
        image.color = targetColorOut;
        alpha = 0f;
        yield return new WaitForSeconds(0.3f);
        while (alpha <= 1)
        {
            Color currentColor = Color.Lerp(startColorIn, targetColorIn, alpha);
            image.color = currentColor;
            yield return new WaitForSeconds(smoothing);
            alpha += 0.1f;
        }
    }
}

