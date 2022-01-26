using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableScript : MonoBehaviour
{
    public List<GameObject> objetosADesabilitar;

    private void OnDisable()
    {
        foreach (var obj in objetosADesabilitar)
        {
            obj.SetActive(false);
        }
    }
}
