using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;

public class Trade : MonoBehaviour
{
    public static Action<Cliente> CommitTrade; 
    public static Trade activeTrade;
    public TMP_Text text;
    public Button acceptBtn;
    public Button rejectBtn;

    public int TradeTime;
    public Image progressBar;
    private float target;


    private Cliente cliente;

    private void OnEnable()
    {
        if (FindObjectOfType<Cliente>() == null)
        {
            gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        if (activeTrade == null)
        {
            activeTrade = this;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }

    }

    public void setClientTrade (Cliente c)
    {
        cliente = c;
        string wantedCrop = "";

        switch (c.wantedCrop)
        {
            case Crop.CropType.Carrot:
                wantedCrop = "carrot";
                break;
            case Crop.CropType.Potatoe:
                wantedCrop = "potatoe";
                break;
            case Crop.CropType.Wheat:
                wantedCrop = "wheat";
                break;
            default:
                break;
        }

        text.text = $" {c.name}: I'm interested in your crops.\n \n ¿Would you trade {c.cropQuantity} {wantedCrop} crops for {c.moneyOffered} $? ";
    }

    public async void startTimer(CancellationToken token)
    {
        await Task.Delay(50);

        target = 0;
        progressBar.fillAmount = 0;
        int currentime = 0;
        do
        {
            if (token.IsCancellationRequested || !Application.isPlaying || !LevelManager.Instance.activeScene.Equals("Shop") || !gameObject.activeSelf) return;

            await Task.Delay(100);
            currentime += 100;
            target = (float)currentime / (float)(TradeTime * 1000);

            if (token.IsCancellationRequested || !Application.isPlaying || !LevelManager.Instance.activeScene.Equals("Shop") || !gameObject.activeSelf) return;

        } while (currentime <= TradeTime * 1000);

        if (token.IsCancellationRequested || !Application.isPlaying || !LevelManager.Instance.activeScene.Equals("Shop") || !gameObject.activeSelf) return;

        cliente.rejectMe();
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, Time.deltaTime * 0.1f);        
    }

    public void acceptTrade()
    {
        switch (cliente.wantedCrop)
        {
            case Crop.CropType.Carrot:
                if (cliente.cropQuantity <= Inventory.nCarrots)
                {
                    CommitTrade?.Invoke(cliente);
                } else
                {
                    AlertsManager.Instance.ShowAlert("You don't have enough Carrots!!");
                }
                cliente.rejectMe();
                break;
            case Crop.CropType.Potatoe:
                if (cliente.cropQuantity <= Inventory.nPotatoes)
                {
                    CommitTrade?.Invoke(cliente);
                }
                else
                {
                    AlertsManager.Instance.ShowAlert("You don't have enough Potatoes!!");
                }
                cliente.rejectMe();
                break;
            case Crop.CropType.Wheat:
                if (cliente.cropQuantity <= Inventory.nWheat)
                {
                    CommitTrade?.Invoke(cliente);
                }
                else
                {
                    AlertsManager.Instance.ShowAlert("You don't have enough Wheat!!");
                }
                cliente.rejectMe();
                break;
            default:
                break;
        }
    }
}
