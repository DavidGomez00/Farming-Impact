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
        Vector3 NextPos = Camera.main.transform.position;

        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) &&
            (Camera.main.transform.position.x > -13 && Camera.main.transform.position.x < 13) &&
            (Camera.main.transform.position.y > -3.4 && Camera.main.transform.position.y < 4.6))
        {
            NextPos += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime * speed;
        }
        
        if (NextPos.x < -13) return;

        if (NextPos.x > 13) return;

        if (NextPos.y < -3.4) return;


        if (NextPos.y > 4.6) return;

        Camera.main.transform.position = NextPos;

    }

    private void zoom()
    {
        if (Input.mouseScrollDelta.y < 0 && Camera.main.orthographicSize <= 11.8)
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
