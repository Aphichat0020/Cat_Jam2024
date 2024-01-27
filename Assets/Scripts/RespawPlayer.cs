using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController playerController;
    public float Max_Cooldown;
    public float _Cooldown;
    public GameObject UI_Respaw;
    public TextMeshProUGUI Cooldown_Text;
    public bool isDaed = false;
   
    public Transform[] spawPoints;
    public Transform MyLocation;

    Rigidbody rb;
    public void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        rb = GetComponent<Rigidbody>(); 
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

    public void PlayerDead()
    {
        UI_Respaw.SetActive(true);
        isDaed = true;

        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;

        _Cooldown = Max_Cooldown;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "OutMap")
        {
            Debug.Log("Hit");
            PlayerDead();
        } 
    }
   
    public void spaw_Player()
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = true;
        rb.isKinematic = false;
        MyLocation.transform.position = spawPoints[Random.Range(0, spawPoints.Length)].transform.position;
        isDaed = false;
    }
}
