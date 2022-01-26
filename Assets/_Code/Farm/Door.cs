using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string nextScene;

    private void Start()
    {
        GetComponent<Clickable>().AccionARealizar.AddListener(delegate { UIManager.Instance.changeScene(nextScene); });
    }
}
