using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class FarmingSpot : MonoBehaviour
{
    public List<FarmingSlot> slots;
    public TMP_Text price;

    public GameObject lockedSpotSprite;
    public static int precioDeDesbloqueo;
    public bool locked;

    private void Start()
    {
        precioDeDesbloqueo = 200;
        price.text = precioDeDesbloqueo.ToString();
        if (locked)
        {
            foreach (var slot in slots)
            {
                slot.GetComponent<Clickable>().enabled = false;
                slot.GetComponent<Collider2D>().enabled = false;
            }

            lockedSpotSprite.SetActive(true);
            //GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            Destroy(lockedSpotSprite);
        }
    }

    public void updatePrice()
    {
        var farmingSpots = FindObjectsOfType<FarmingSpot>();

        foreach (var farmingSpot in farmingSpots)
        {
            if (farmingSpot.price != null)
            {
                farmingSpot.price.text = precioDeDesbloqueo.ToString();
            }
        }
    }

    public void unlock()
    {
        if (Inventory.money < precioDeDesbloqueo) {
            AlertsManager.Instance.ShowAlert("You don't have enough money to do that");
            return;
        }
        
        Inventory.Instance.addMoney(-precioDeDesbloqueo);
        precioDeDesbloqueo = 2 * precioDeDesbloqueo;
        updatePrice();
        
        foreach (var slot in slots)
        {
            slot.GetComponent<Clickable>().enabled = true;
            slot.GetComponent<Collider2D>().enabled = true;
        }

        Destroy(lockedSpotSprite);
    }
}
