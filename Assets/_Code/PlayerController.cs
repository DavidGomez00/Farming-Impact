using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public enum Estados {plantCarrot, plantPotatoe, plantWheat, regar, UI, none};

    public Estados est;

    private RatonController raton;

    private void Start()
    {
        raton = GetComponent<RatonController>();
    }

    public void ChangeState(int state)
    {
        if ((int)est == state)
        {
            est = Estados.none;
        } else
        {
            est = (Estados)state;
        }

        raton.cambiarSprite(est);
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

