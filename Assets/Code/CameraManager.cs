using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public Camera camara;
    public CameraMovement cMovement;

    public Vector3 cameraShopPosition;
    public Vector3 cameraFarmPosition;
    public float cameraFarmZoom;

    public void activateShopCamera ()
    {
        camara.transform.position = cameraShopPosition;
        cameraFarmZoom = camara.orthographicSize;
        camara.orthographicSize = 10;
        cMovement.enabled = false;
    }
    
    public void activateFarmCamera ()
    {
        camara.transform.position = cameraFarmPosition;
        camara.orthographicSize = cameraFarmZoom;
        cMovement.enabled = true;
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
