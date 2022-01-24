using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Canvas mainCanvas;
    public GameObject ShopCanvas;
    public GameObject FarmCanvas;
    public GameObject GarageCanvas;
    public GameObject StartScreenCanvas;
    public GameObject EndScreenCanvas;
    public GameObject TopBar;
    public GameObject esqUI;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;

        if (esqUI.activeSelf)
        {
            esqUI.SetActive(false);
        }
        else
        {
            esqUI.SetActive(true);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void changeScene(string scene)
    {
        if (!TopBar.activeInHierarchy)
        {
            TopBar.SetActive(true);
        }

        PlayerController.Instance.ChangeState((int)PlayerController.Estados.none);

        switch (SceneManager.GetActiveScene().name)
        {
            case "Shop":
                FindObjectOfType<ClientSpawner>().clientSpawning = false;
                ShopCanvas?.SetActive(false);
                break;
            case "Farm":
                CameraManager.Instance.cameraFarmPosition = Camera.main.transform.position;
                Ground.Instance?.gameObject.SetActive(false);
                FarmCanvas?.SetActive(false);
                break;
            case "Garage":
                GarageCanvas?.SetActive(false);
                break;
            case "StartScreen":
                StartScreenCanvas?.SetActive(false);
                break;
            default:
                break;
        }


        switch (scene)
        {
            case "Shop":
                CameraManager.Instance.activateShopCamera();
                ShopCanvas?.SetActive(true);
                break;
            case "Farm":
                CameraManager.Instance.activateFarmCamera();
                Ground.Instance?.gameObject.SetActive(true);
                FarmCanvas?.SetActive(true);
                break;
            case "Garage":
                CameraManager.Instance.activateShopCamera();
                GarageCanvas?.SetActive(true);
                break;
            default:
                break;
        }

        LevelManager.Instance.LoadScene(scene);
    }

    private void Awake()
    {
        mainCanvas.worldCamera = Camera.main;

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
