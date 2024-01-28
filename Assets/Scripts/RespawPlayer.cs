using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Photon.Pun.Demo.PunBasics;

public class RespawPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController playerController;
    public float Max_Cooldown;
    public float _Cooldown;
    public GameObject UI_Respaw;
    public TextMeshProUGUI Cooldown_Text;
    public GameObject UI_RespawIsSolo;
    public TextMeshProUGUI Cooldown_Text_isSolo;
    public bool isDaed = false;
    public PlayerBuffHolder playerBuffHolder;
    Rigidbody rb;
    GameManager gameManager;
    public Transform[] spawPoints;
    public Transform MyLocation;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
        playerBuffHolder = GetComponent<PlayerBuffHolder>();
        playerController = GetComponentInParent<PlayerController>();
    }
    public void Update()
    {
        if (isDaed)
        {
             _Cooldown -=  Time.deltaTime;
            Cooldown_Text.text =Mathf.Round(_Cooldown).ToString();
             Cooldown_Text_isSolo.text = Mathf.Round(_Cooldown).ToString();
            if (_Cooldown <= 0)
            {
                _Cooldown = 0;
                
                spaw_Player();
                if(ModeManager.instance.is_Solo == true)
                {
                    UI_RespawIsSolo.SetActive(false);
                }
                if (ModeManager.instance.is_Online == true)
                {
                    UI_Respaw.SetActive(false);
                }
               
            }
        }
       
    }

    public void PlayerDead(GameObject player)
    {
        MyLocation = player.transform;
        playerController = MyLocation.GetComponent<PlayerController>();
        playerBuffHolder = MyLocation.GetComponent<PlayerBuffHolder>();
        rb = MyLocation.GetComponent<Rigidbody>();
        MyLocation.gameObject.SetActive(false);


        isDaed = true;

        playerController.isDead = true;

        _Cooldown = Max_Cooldown;

        if (playerController.playerLife > 0)
        {
            if (ModeManager.instance.is_Solo == true)
            {
                UI_RespawIsSolo.SetActive(true);
                AudioManager_New.instance.PlaySFX("Die");
            }
            if (ModeManager.instance.is_Online == true)
            {
                UI_Respaw.SetActive(true);
            }
            playerController.playerLife -= 1;
        }
        else
        {

            if (playerController.isPlayer2)
            {
                gameManager.P2LoseGameCoop();
               
            }
            else if(!playerController.isPlayer2)
            {
                gameManager.P1LoseGameCoop();
            }
            playerController.islose = true;
        }
    }
   
    public void spaw_Player()
    {
        MyLocation.gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        playerController.playerHP = playerController.MaxHP;
        playerBuffHolder.PlayerBuffReset();
        playerController.isDead = false;

        MyLocation.transform.position = spawPoints[Random.Range(0, spawPoints.Length)].transform.position;
        isDaed = false;
    }
}
