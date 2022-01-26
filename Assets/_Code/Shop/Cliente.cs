using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Cliente : MonoBehaviour
{
    public const int CROPS_QUANTITY_HIGH = 30;
    public const int CROPS_QUANTITY_LOW = 2;
    
    public const int MONEY_MAX_VARIANCE = 5;

    public string nombre;

    public Crop.CropType wantedCrop;
    public int cropQuantity;
    public int moneyOffered;

    private CancellationTokenSource clientTimerCancelation;

    private string[] randomNames = { "Bovir",
                                    "Vaivreads",
                                    "Itaks",
                                    "Falted",
                                    "Stuur",
                                    "Qahirs",
                                    "Drexan",
                                    "Qehall",
                                    "Surqras",
                                    "Kohnol",
                                    "Yumphul",
                                    "Scrongea",
                                    "Bammi",
                                    "Chinphix",
                                    "Shirit",
                                    "Theeco",
                                    "Ghidul",
                                    "Keinge",
                                    "Drunqin",
                                    "Aelxak"};

    private void Start()
    {
        name = randomNames[Random.Range(0, randomNames.Length)];
        nombre = name;
        wantedCrop = (Crop.CropType)Random.Range(0, 3);
        cropQuantity = Random.Range(CROPS_QUANTITY_LOW, CROPS_QUANTITY_HIGH);
        clientTimerCancelation = new CancellationTokenSource();

        switch (wantedCrop)
        {
            case Crop.CropType.Carrot:
                moneyOffered = cropQuantity * Crop.CarrotPrice;
                break;
            case Crop.CropType.Potatoe:
                moneyOffered = cropQuantity * Crop.PotatoePrice;
                break;
            case Crop.CropType.Wheat:
                moneyOffered = cropQuantity * Crop.WheatPrice;
                break;
            default:
                break;
        }

        if (moneyOffered - MONEY_MAX_VARIANCE <= 0)
        {
            moneyOffered = 1;
        } else
        {
            moneyOffered += Random.Range(-MONEY_MAX_VARIANCE, MONEY_MAX_VARIANCE);
        }

        Trade.activeTrade.gameObject.SetActive(true);
        Trade.activeTrade.setClientTrade(this);
        Trade.activeTrade.startTimer(clientTimerCancelation.Token);
        Trade.activeTrade.rejectBtn.onClick.AddListener(rejectMe);
    }

    public void rejectMe()
    {
        clientTimerCancelation.Cancel();
        Trade.activeTrade.rejectBtn.onClick.RemoveAllListeners();
        Trade.activeTrade.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
