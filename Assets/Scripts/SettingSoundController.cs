using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSoundController : MonoBehaviour
{
   public Slider _MusicSlider, _SFXSlider;
    public GameObject SettingUI;
    public void Start()
    {
        
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingUI.SetActive(true);
        }
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
