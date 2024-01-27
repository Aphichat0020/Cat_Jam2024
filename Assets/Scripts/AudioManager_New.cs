using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public  class AudioManager_New : MonoBehaviour
{
    public static AudioManager_New instance;
    public Sound[] MusicSounds, SFXSounds;
    public AudioSource MusicSource, SFXSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        Playmusic("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playmusic(String name)
    {
        Sound s = Array.Find(MusicSounds,x => x.Name == name);
        if(s == null)
        {
            Debug.Log("MusicSounds Not Found");
        }
        else
        {
            MusicSource.clip = s.clip;
            MusicSource.Play();
        }
    }
    public void PlaySFX(String name)//AudioManager_New.instance.PlaySFX("Name");
    {
        Sound s = Array.Find(SFXSounds, x => x.Name == name);
        if (s == null)
        {
            Debug.Log("SFXSounds Not Found");
        }
        else
        {
            SFXSource.clip = s.clip;
            SFXSource.Play();
        }
    }
    public void ToggleMusic()   
    {
        MusicSource.mute = !MusicSource.mute;
    }
    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }
    public void MusicVolume(float Volume)
    {
        MusicSource.volume = Volume;
    }
    public void SFXVolume(float Volume)
    {
        SFXSource.volume = Volume;
    }




    /////
    ///
    public void Click1()
    {
        AudioManager_New.instance.PlaySFX("Click1");

    }
   
}
