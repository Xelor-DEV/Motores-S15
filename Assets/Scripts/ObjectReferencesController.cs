using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class ObjectReferencesController : MonoBehaviour
{
    private UIManagerController uiManager;
    public UnityEvent OnChangeScene;
    private void Start()
    {
        OnChangeScene.Invoke();
        uiManager = UIManagerController.Instance;
        AudioManagerController.Instance.LoadAudioSettings();
    }
    public void AssignMusicSlider(Slider music)
    {
        AudioManagerController.Instance.MusicConfiguration = music;
    }
    public void AssignSFXSlider(Slider sfx)
    {
        AudioManagerController.Instance.SFXConfiguration = sfx;
    }
    public void AssignMasterSlider(Slider master)
    {
        AudioManagerController.Instance.MasterConfiguration = master;
    }
    public void AssignNameOfNPCText(TMP_Text nameOfNPC_text)
    {
        UIManagerController.Instance.NameOfNPC = nameOfNPC_text;
    }
    public void AssignMessageText(TMP_Text nameOfNPC_text)
    {
        UIManagerController.Instance.Message = nameOfNPC_text;
    }
    public void AssignMenu(GameObject menu)
    {
        UIManagerController.Instance.Menu = menu;
    }
    public void AssignDialogue(GameObject dialogue)
    {
        UIManagerController.Instance.Dialogue = dialogue;
    }
    public void AssignFadeImage(Image fade)
    {
        UIManagerController.Instance.ImageFade = fade;
    }
    public void ActiveMenu()
    {
        UIManagerController.Instance.ActivateMenu();
    }
    public void DisableMenu()
    {
        UIManagerController.Instance.DisableMenu();
    }
    public void SetVolumeOfMusic()
    {
        AudioManagerController.Instance.SetVolumeOfMusic();
    }
    public void SetVolumeOfSfx()
    {
        AudioManagerController.Instance.SetVolumeOfSfx();
    }
    public void SetVolumeOfMaster()
    {
        AudioManagerController.Instance.SetVolumeOfMaster();
    }
}
