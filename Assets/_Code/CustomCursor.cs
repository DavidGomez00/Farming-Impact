using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private Vector3 mousePos;
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
