using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnSceneChange : MonoBehaviour
{
    public static dontDestroyOnSceneChange Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
