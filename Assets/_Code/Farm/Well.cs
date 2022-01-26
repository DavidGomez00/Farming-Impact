using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Clickable>().AccionARealizar.AddListener(delegate { PlayerController.Instance.ChangeState(3); });
    }
}
