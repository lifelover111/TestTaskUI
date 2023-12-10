using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundSource;

    bool sound = true;
    bool music = true;

    public void SwitchSound()
    {
        sound = !sound;
        soundSource.enabled = sound;
    }
    public void SwitchMusic()
    {
        music = !music;
        musicSource.enabled = music;
    }

    public void PlayClick()
    {
        if(soundSource.enabled)
            soundSource.Play();
    }
}
