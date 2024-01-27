using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.FilePathAttribute;

public class RespawPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController playerController;
    public float Max_Cooldown;
    public float _Cooldown;
    public GameObject UI_Respaw;
    public TextMeshProUGUI Cooldown_Text;
    public bool isDaed = false;
    public PlayerBuffHolder playerBuffHolder;
    Rigidbody rb;

    public Transform[] spawPoints;
    public Transform MyLocation;

    public void Start()
    {
        playerBuffHolder = GetComponent<PlayerBuffHolder>();
        playerController = GetComponentInParent<PlayerController>();
    }
    public void Update()
    {
        if (isDaed)
        {
             _Cooldown -=  Time.deltaTime;
              Cooldown_Text.text =Mathf.Round(_Cooldown).ToString();    
            if (_Cooldown <= 0)
            {
                _Cooldown = 0;
                
                spaw_Player();
                UI_Respaw.SetActive(false);
            }
        }
       
    }

    public void PlayerDead(GameObject player)
    {
        MyLocation = player.transform;
        playerController = MyLocation.GetComponent<PlayerController>();
        playerBuffHolder = MyLocation.GetComponent<PlayerBuffHolder>();
        rb = MyLocation.GetComponent<Rigidbody>();

        UI_Respaw.SetActive(true);
        isDaed = true;

        playerController.isDead = true;

        _Cooldown = Max_Cooldown;
    }
   
    public void spaw_Player()
    {
        rb.velocity = Vector3.zero;
        playerController.playerHP = playerController.MaxHP;
        playerBuffHolder.PlayerBuffReset();
        playerController.isDead = false;

        MyLocation.transform.position = spawPoints[Random.Range(0, spawPoints.Length)].transform.position;
        isDaed = false;
    }
}
