using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip shipCrash;
    public AudioClip takingOff;
    public AudioClip startScreenAudio;
    public AudioClip[] other;

    private bool music;
    private int i;

    private async void Start()
    {
        source.loop = false;
        music = false;
        source.clip = shipCrash;
        source.Play();
        await Task.Delay(14300);
        music = true;
    }

    public async void playFinalVideo()
    {
        music = false;
        source.clip = takingOff;
        source.Play();
        await Task.Delay(11300);
        source.clip = other[1];
        source.Play();
    }

    private void Update()
    {
        if (music)
        {
            if (LevelManager.Instance.activeScene.Equals("StartScreen"))
            {
                if (source.clip == null || !source.clip.Equals(startScreenAudio))
                {
                    source.Stop();
                    source.clip = startScreenAudio;
                    source.Play();
                }
            }
            else
            {
                if (source.clip == null || source.clip.Equals(startScreenAudio))
                {
                    source.clip = other[0];
                }
                else if (!source.isPlaying)
                {
                    source.clip = other[i++ % other.Length];
                    source.Play();
                }
            }
        }
    }
}
