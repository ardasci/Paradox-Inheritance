using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singeltonObject : MonoBehaviour
{
    public static singeltonObject Instance { get; set; }

    public List<ScriptableObject> Item = new List<ScriptableObject>();
    private void Awake()
    {
        SingletonThisObject();
    }

    private void SingletonThisObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
