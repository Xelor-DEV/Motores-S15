using UnityEngine;
[CreateAssetMenu(fileName = "NPC Data", menuName = "ScriptableObjects/NPC Data", order = 1)]
public class NPCData : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    [SerializeField] private string npcName;
    public string NpcName
    {
        get
        {
            return npcName;
        }
    }
    [SerializeField] private string message;
    public string Message
    {
        get
        {
            return message;
        }
    }
    [SerializeField] private float waitTime;
    public float WaitTime
    {
        get
        {
            return waitTime;
        }
    }
}
