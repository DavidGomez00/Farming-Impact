using UnityEngine;
using System;

[RequireComponent(typeof(Clickable))]
public class FarmingSlot : MonoBehaviour
{
    public static Action<Crop> Harvest;

    public Crop.CropType cropType;
    public Crop plantedCrop;
    private SpriteRenderer spriteRenderer;
    private PlayerController pc;

    [Header("Crops")]
    public GameObject carrot;
    public GameObject potatoe;
    public GameObject wheat;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        pc = PlayerController.Instance;
        plantedCrop = null;
        GetComponent<Clickable>().AccionARealizar.AddListener(plant);
    }

    public void plant()
    {
        switch (pc.est)
        {
            case PlayerController.Estados.plantCarrot:
                if (plantedCrop != null)
                {
                    AlertsManager.Instance.ShowAlert("There is already something planted there. Wait for it to grow before planting something else!");
                }
                else if (Inventory.nCarrots <= 0)
                {
                    AlertsManager.Instance.ShowAlert("You don't have enough carrots to plant!!");
                }
                else
                {
                    Inventory.Instance.addCrop(Crop.CropType.Carrot, -1);
                    plantedCrop = Instantiate(carrot, this.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity, this.transform)
                        .GetComponent<Crop>();
                    plantedCrop.type = Crop.CropType.Carrot;
                }
                break;

            case PlayerController.Estados.plantPotatoe:
                if (plantedCrop != null)
                {
                    AlertsManager.Instance.ShowAlert("There is already something planted there. Wait for it to grow before planting something else!");
                }
                else if (Inventory.nPotatoes <= 0)
                {
                    AlertsManager.Instance.ShowAlert("You don't have enough potatoes to plant!!");
                }
                else
                {
                    Inventory.Instance.addCrop(Crop.CropType.Potatoe, -1);
                    plantedCrop = Instantiate(potatoe, this.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity, this.transform)
                        .GetComponent<Crop>();
                    plantedCrop.type = Crop.CropType.Potatoe;
                }
                break;

            case PlayerController.Estados.plantWheat:
                if (plantedCrop != null)
                {
                    AlertsManager.Instance.ShowAlert("There is already something planted there. Wait for it to grow before planting something else!");
                }
                else if (Inventory.nWheat <= 0)
                {
                    AlertsManager.Instance.ShowAlert("You don't have enough wheat to plant!!");
                }
                else
                {
                    Inventory.Instance.addCrop(Crop.CropType.Wheat, -1);
                    plantedCrop = Instantiate(wheat, this.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity, this.transform)
                        .GetComponent<Crop>();
                    plantedCrop.type = Crop.CropType.Wheat;
                }
                break;
            case PlayerController.Estados.regar:
                if (plantedCrop != null)
                {
                    plantedCrop.water();
                    spriteRenderer.color = new Color(0.6037736f, 0.5300194f, 0.4015664f, 1);              
                }
                break;
            case PlayerController.Estados.none:
                if (plantedCrop == null)
                {
                    AlertsManager.Instance.ShowAlert("There is nothing planted there!!");
                }
                else if (!plantedCrop.GetComponent<Crop>().grown)
                {
                    AlertsManager.Instance.ShowAlert("The crop isn't grown yet!!");
                } else
                {
                    Harvest?.Invoke(plantedCrop);
                    Destroy(plantedCrop.gameObject);
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                }
                break;

            default:
                break;

        }
    }
}
