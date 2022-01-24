using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedsSac : MonoBehaviour
{
    public enum SacType {PotatoeSac, CarrotSac, WheatSac};
    public SacType type;
    
    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case SacType.PotatoeSac:
                if (Inventory.nPotatoes > 0)
                {
                    GetComponent<Clickable>().AccionARealizar.AddListener(delegate { PlayerController.Instance.ChangeState(1); });
                }
                break;
            case SacType.CarrotSac:
                if (Inventory.nCarrots > 0)
                {
                    GetComponent<Clickable>().AccionARealizar.AddListener(delegate { PlayerController.Instance.ChangeState(0); });
                }
                break;
            case SacType.WheatSac:
                if (Inventory.nWheat > 0)
                {
                    GetComponent<Clickable>().AccionARealizar.AddListener(delegate { PlayerController.Instance.ChangeState(2); });
                }
                break;
            default:
                break;
        }
    }
}
