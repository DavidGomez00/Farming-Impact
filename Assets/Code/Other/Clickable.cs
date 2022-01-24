using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Clickable : MonoBehaviour
{
    public UnityEvent AccionARealizar;

    public bool alwaysPlay;
    public AudioClip[] audioClips;
    public PlayerController.Estados[] estados;
    public string[] animationTriggers;



    private PlayerController playerController;
    private Vector3 defaultSize;


    private void Start()
    {
        defaultSize = transform.localScale;
        playerController = PlayerController.Instance;
    }

    private void OnMouseEnter()
    {
        transform.localScale = defaultSize * 1.1f;
    }


    private void OnMouseExit()
    {
        transform.localScale = defaultSize;
    }
    private void OnMouseDown()
    {
        AccionARealizar.Invoke();

        if (alwaysPlay)
        {
            RatonController.Instance.audioSource.clip = audioClips[0];
            if (animationTriggers[0] != null) RatonController.Instance.animator.SetTrigger(animationTriggers[0]);
        }
        else
        {
            for (int i = 0; i < estados.Length; i++)
            {
                if (playerController.est == estados[i] && audioClips[i] != null)
                {
                    RatonController.Instance.audioSource.clip = audioClips[i];
                    if (animationTriggers[i] != null) RatonController.Instance.animator.SetTrigger(animationTriggers[i]);
                }
            }
        }
    }
}
