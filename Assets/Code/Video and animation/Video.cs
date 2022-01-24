using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public MusicManager musicManager;
    public GameObject endScreenCanvas;

    public void playVideo()
    {
        musicManager.playFinalVideo();
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
        endScreenCanvas.SetActive(true);
    }

    private void CheckOver(VideoPlayer vp)
    {
        vp.Stop();
    }

    private void OnEnable()
    {
        Inventory.RepairShip += playVideo;
    }

    private void OnDisable()
    {
        Inventory.RepairShip -= playVideo;
    }
}
