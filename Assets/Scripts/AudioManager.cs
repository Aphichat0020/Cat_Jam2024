using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource ClickSource;

    [SerializeField] List<AudioClip> ClickClips = new List<AudioClip>();

    [SerializeField] AudioSource BGM;

    [SerializeField] List<AudioClip> BGMClips = new List<AudioClip>();
    //public GameObject Start_G;
    public bool Imback = false;

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    public bool openSFX;
    public int alternate_Sound_Shoot;
   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy(gameObject);
        }
    }
    public void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        alternate_Sound_Shoot = 0;
        if (SceneManager.GetActiveScene().name == "Location-basedGame")
        {
            BGM1();
           

        }
        // if (SceneManager.GetActiveScene().name == "AR_Team_Winner")
        // {
        //     BGM2();
        // }
    }
   
    public void ClickSFX_Shoot()
    {
        AudioClip clip = ClickClips[0];
        ClickSource.PlayOneShot(clip);
    }
 


    public void BGM1()
    {
        AudioClip clipBGM = BGMClips[0];
        BGM.clip = BGMClips[0];
        BGM.Play();

    }
   

    public void stopbgm()
    {
        BGM.Stop();
        Debug.Log("stop");
    }
    public void stopSFX()
    {
        ClickSource.Stop();
        Debug.Log("stop");
    }

  
    public void LoadVolum()//Volum saved in VolumSetting.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }

}