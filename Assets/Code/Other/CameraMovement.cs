using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;


    public float speed;
    public float scrollSpeed;

    private void Update()
    {
        move();
        zoom();
    }

    private void move()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && (Camera.main.transform.position.x > -13 && Camera.main.transform.position.x < 13) && (Camera.main.transform.position.y > -3.4 && Camera.main.transform.position.y < 4.6))
        {
            Camera.main.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime * speed;
        }
        
        if (Camera.main.transform.position.x < -13) {
            Camera.main.transform.position = new Vector3(-12.8f, Camera.main.transform.position.y, -10);
        }

        if (Camera.main.transform.position.x > 13)
        {
            Camera.main.transform.position = new Vector3(12.8f, Camera.main.transform.position.y, -10);
        }

        if (Camera.main.transform.position.y < -3.4)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, -3.3f, -10);
        }

        if (Camera.main.transform.position.y > 4.6)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 4.5f, -10);
        }
    }

    private void zoom()
    {
        if (Input.mouseScrollDelta.y < 0 && Camera.main.orthographicSize <= 11.8f)
        {
            Camera.main.orthographicSize += Time.deltaTime * scrollSpeed * 10;
        }
        else if (Input.mouseScrollDelta.y > 0 && Camera.main.orthographicSize >= 6)
        {
            Camera.main.orthographicSize -= Time.deltaTime * scrollSpeed * 10;
        }
    }


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
