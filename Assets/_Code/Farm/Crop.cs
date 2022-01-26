using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    // atributes
    public bool grown { get; private set; }
    public bool watered { get; private set; }
    public int phase { get; private set; }

    public static int CarrotPrice = 4;
    public static int PotatoePrice = 2;
    public static int WheatPrice = 8;

    public float timeWhenPlanted;
    public float timeUntillNextPhase;

    public Sprite halfGrownCrop;
    public Sprite fullyGrownCrop;

    private SpriteRenderer spriteRenderer;

    public enum CropType
    {
        Carrot, Potatoe, Wheat, None
    }
    public CropType type;


    public List<CropType> enumCropType()
    {
        List<CropType> crops = new List<CropType> { CropType.Carrot, CropType.Potatoe, CropType.Wheat };
        return crops;
    }

    public void Start()
    {
        // references
        spriteRenderer = GetComponent<SpriteRenderer>();

        // logic
        grown = false;
        watered = false;
        phase = 0;
        timeUntillNextPhase = 15f;
    }

    public void Update()
    {
        if (!grown && watered && TimeManager.CurrentTime - timeWhenPlanted > timeUntillNextPhase)
        {
            // check if is fully grown   
            if (TimeManager.CurrentTime - timeWhenPlanted > 2 * timeUntillNextPhase)
            {
                phase = 2;
            }
            else
            {
                phase++;
            }
            if (phase == 1)
            {
                // sprite a medio camino
                spriteRenderer.sprite = halfGrownCrop;
                timeWhenPlanted = TimeManager.CurrentTime;

            } else if (phase == 2)
            {
                // sprite full grown
                spriteRenderer.sprite = fullyGrownCrop;
                grown = true;
            }
        }
    }

    public void water()
    {
        watered = true;
        timeWhenPlanted = TimeManager.CurrentTime;
    }
}
