using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource ClickSource;

    [SerializeField] List<AudioClip> ClickClips = new List<AudioClip>();

    [SerializeField] AudioSource BGM;

    [SerializeField] List<AudioClip> BGMClips = new List<AudioClip>();
    
    

    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";


    // Start is called before the first frame update

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

    public void Start()
    {
        BGM_1();
    }
    public void BGM_1()
    {
        AudioClip clip = BGMClips[0];
        ClickSource.Play();
    }
    

    public void LoadVolum()//Volum saved in VolumSetting.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }

}
