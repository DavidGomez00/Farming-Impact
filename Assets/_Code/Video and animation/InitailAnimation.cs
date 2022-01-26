using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;

public class InitailAnimation : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public MusicManager musicManager;
    public static Action StartingAnimation;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        StartingAnimation?.Invoke();
        videoPlayer.Play();
        videoPlayer.loopPointReached += CheckOver;
    }

    private void CheckOver(VideoPlayer vp)
    {
        vp.Stop();
    }
}
