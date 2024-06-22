using UnityEngine;
[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/AudioSettings", order = 1)]
public class AudioSettings : ScriptableObject
{
    public float musicVolume;
    public float sfxVolume;
    public float masterVolume;
}
