using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public string SceneName
    {
        get
        {
            return sceneName;
        }
    }
}
