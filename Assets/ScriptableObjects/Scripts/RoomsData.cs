using UnityEngine;
[CreateAssetMenu(fileName = "RoomsData", menuName = "ScriptableObjects/RoomsData", order = 1)]
public class RoomsData : ScriptableObject
{
    [SerializeField] private int sfx_player_passed_enter;
    [SerializeField] private int sfx_player_passed_exit;
    [SerializeField] private int music_background;
    [SerializeField] private bool hasPlayerPassed = false;
    public int Sfx_player_passed_enter
    {
        get
        {
            return sfx_player_passed_enter;
        }
        set
        {
            sfx_player_passed_enter = value;
        }
    }
    public int Sfx_player_passed_exit
    {
        get
        {
            return sfx_player_passed_exit;
        }
        set
        {
            sfx_player_passed_exit = value;
        }
    }
    public int Music_background
    {
        get
        {
            return music_background;
        }
        set
        {
            music_background = value;
        }
    }
    public bool HasPlayerPassed
    {
        get
        {
            return hasPlayerPassed;
        }
        set
        {
            hasPlayerPassed = value;
        }
    }
}