using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsManager : MonoBehaviour
{
    public static AlertsManager Instance;
    public GameObject alertPrefab;

    private GameObject activeAlert;
    
    public void ShowAlert(string text)
    {
        if (activeAlert != null)
        {
            Destroy(activeAlert);
        }

        activeAlert = Instantiate(alertPrefab, UIManager.Instance.mainCanvas.transform);
        activeAlert.GetComponentInChildren<TMPro.TMP_Text>().text = text;
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
