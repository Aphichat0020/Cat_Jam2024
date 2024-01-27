using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingSoundController : MonoBehaviour
{
   public Slider _MusicSlider, _SFXSlider;
    public GameObject SettingUI;

    [SerializeField] AudioMixer mixer;

    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        _MusicSlider.onValueChanged.AddListener(SetMusicVolume);
        _SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    void Start()
    {
        _MusicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 1f);
        _SFXSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 1f);

    }
    public void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Escape))
        //{
        //    SettingUI.SetActive(true);
        //}
        if (Input.GetKeyDown(KeyCode.Escape) && SettingUI.activeInHierarchy == false)
        {
            SettingUI.SetActive(true);
            AudioManager_New.instance.PlaySFX("Click1");
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && SettingUI.activeInHierarchy == true)
        {
           SettingUI.SetActive(false);
            AudioManager_New.instance.PlaySFX("Click1");
        }
    }

    public void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, _MusicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, _SFXSlider.value);
    }
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
    public void ToggleMusic()
    {
        AudioManager_New.instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        AudioManager_New.instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        AudioManager_New.instance.MusicVolume(_MusicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager_New.instance.SFXVolume(_SFXSlider.value);
    }
}

