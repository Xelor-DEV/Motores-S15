using UnityEngine;
using System.Collections;

public class PuertasController : MonoBehaviour
{
    [SerializeField] private RoomsData data;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (data.HasPlayerPassed == false)
            {
                UIManagerController.Instance.StartFade();
                AudioManagerController.Instance.PlaySfx(data.Sfx_player_passed_enter);
                data.HasPlayerPassed = true;
                AudioManagerController.Instance.PlayMusic(data.Music_background);
            }
            else
            {
                UIManagerController.Instance.StartFade();
                AudioManagerController.Instance.PlaySfx(data.Sfx_player_passed_exit);
                data.HasPlayerPassed = false;
                AudioManagerController.Instance.MusicAudioSource.Stop();
            } 
        }
    }
}