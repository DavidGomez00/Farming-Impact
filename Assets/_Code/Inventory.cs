using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    // Actions
    public static Action RepairShip;

    // provisional crops
    public static int nCarrots { get; private set; }
    public static int nPotatoes { get; private set; }
    public static int nWheat { get; private set; }
    public static int money { get; private set; }

    public TMP_Text carrotTxt;
    public TMP_Text potatoTxt;
    public TMP_Text wheatTxt;
    public TMP_Text moneyTxt;

    // harvesting quantities
    public int carrotsHarvested;
    public int potatoesHarvested;
    public int wheatHarvested;

    public void Start()
    {
        // harvesting initial stats
        carrotsHarvested = 3;
        potatoesHarvested = 4;
        wheatHarvested = 2;

        // initial crops
        nCarrots = 1;
        nPotatoes = 1;
        nWheat = 1;

        carrotTxt.text = ":" + nCarrots;
        potatoTxt.text = ":" + nPotatoes;
        wheatTxt.text = ":" + nWheat;

        // initial money
        money = 1000;
        moneyTxt.text = ":" + money;
    }

    private void harvestCrop(Crop crop)
    {
        int num = 0;

        switch (crop.type)
        {
            case Crop.CropType.Carrot:
                num = carrotsHarvested;
                break;
            case Crop.CropType.Potatoe:
                num = potatoesHarvested;
                break;
            case Crop.CropType.Wheat:
                num = wheatHarvested;
                break;
            default:
                break;
        }
        addCrop(crop.type, num);
    }

    public void addCrop(Crop.CropType type, int num)
    {
        switch (type)
        {
            case Crop.CropType.Carrot:
                nCarrots += num;
                carrotTxt.text = ":" + nCarrots;
                break;
            case Crop.CropType.Potatoe:
                nPotatoes += num;
                potatoTxt.text = ":" + nPotatoes;
                break;
            case Crop.CropType.Wheat:
                nWheat += num;
                wheatTxt.text = ":" + nWheat;
                break;
            default:
                break;
        }
    }

    public void addMoney(int num)
    {
        money += num;
        moneyTxt.text = ":" + money;
    }
 
    private void OnEnable()
    {
        FarmingSlot.Harvest += harvestCrop;
        Trade.CommitTrade += commitTrade;
    }

    private void OnDisable()
    {
        FarmingSlot.Harvest -= harvestCrop;
        Trade.CommitTrade -= commitTrade;
    }

    private void commitTrade(Cliente clientRef)
    {
        // retrieve crops
        addCrop(clientRef.wantedCrop, -clientRef.cropQuantity);

        // add money
        addMoney(clientRef.moneyOffered);
    }

    public void repairShip()
    {
        // Check if there is enough money
        if (money < 400)
        {
            AlertsManager.Instance.ShowAlert("Not enough money.");
        }
        else 
        {
            // TODO: Action
            addMoney(-400);
            RepairShip?.Invoke();
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
