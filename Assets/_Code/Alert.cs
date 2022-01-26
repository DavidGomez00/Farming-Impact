using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    Clickable[] clickables;

    private void Start()
    {
        clickables = FindObjectsOfType<Clickable>();
        foreach (var item in clickables)
        {
            item.ClickEnabled = false;
        }
    }

    public void ExitAlert()
    {
        foreach (var item in clickables)
        {
            item.ClickEnabled = true;
        }

        Destroy(gameObject);
    }
}
