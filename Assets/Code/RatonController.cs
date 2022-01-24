using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatonController : MonoBehaviour
{
    public static RatonController Instance;

    public Sprite mouseBase;
    public Sprite mouseCarrot;
    public Sprite mousePotato;
    public Sprite mouseWheat;
    public Sprite mouseRegar;

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip defaultSound;
    public AudioClip waterSound;
    public AudioClip harvestSound;

    public CustomCursor cursor;
    private PlayerController playerController;

    private void Start()
    {
        Cursor.visible = false;
        playerController = GetComponent<PlayerController>();
        cursor.spriteRenderer.sprite = mouseBase;
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerController.ChangeState(5);
            audioSource.clip = defaultSound;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.Play();
        }
    }

    public void cambiarSprite(PlayerController.Estados est)
    {
        switch (est)
        {
            case PlayerController.Estados.plantCarrot:
                cursor.spriteRenderer.sprite = mouseCarrot;
                break;
            case PlayerController.Estados.plantPotatoe:
                cursor.spriteRenderer.sprite = mousePotato;
                break;
            case PlayerController.Estados.plantWheat:
                cursor.spriteRenderer.sprite = mouseWheat;
                break;
            case PlayerController.Estados.regar:
                cursor.spriteRenderer.sprite = mouseRegar;
                break;
            case PlayerController.Estados.UI:
                cursor.spriteRenderer.sprite = mouseBase;
                break;
            case PlayerController.Estados.none:
                cursor.spriteRenderer.sprite = mouseBase;
                break;
            default:
                break;
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
