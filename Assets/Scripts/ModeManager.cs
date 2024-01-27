using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public static ModeManager instance; 
    public bool is_Solo;
    public bool is_Online;
    public Camera MainCameraPlayer1;
    public GameObject MainCameraPlayer2;
    


   
    // Start is called before the first frame update
    public void Awake()
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void solo()
    {
        is_Solo = true;

    }
    public void online()
    {
        is_Online = true;
        MainCameraPlayer1.rect = new Rect(0f,0f,0.5f,1f);
        MainCameraPlayer2.SetActive(true);
    }
    public void black()
    {
        is_Solo = false;
        is_Online = false;
    }
}
