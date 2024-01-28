 using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class RespawAI : MonoBehaviour
{
    EnemyAI enemyAI;
    GameManager gameManager;
    // PlayerController AIController;
    public float _Cooldown;
    public float Max_Cooldown;


    public bool isDaed = false;

    public Transform[] spawPoints;
    public Transform MyLocation;

    Rigidbody rb;
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _Cooldown = Max_Cooldown;
        enemyAI = GetComponentInParent<EnemyAI>();
        //playerController = GetComponentInParent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (!gameManager)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        if (isDaed)
        {
            _Cooldown -= Time.deltaTime;
            // Cooldown_Text.text = Mathf.Round(_Cooldown).ToString();
            if (_Cooldown <= 0)
            {
                _Cooldown = 0;

                spaw_AI();
                //  UI_Respaw.SetActive(false);
            }
        }

    }

    public void AIDead()
    {
        // UI_Respaw.SetActive(true);
        isDaed = true;
        if (enemyAI.enemyLife > 0)
        {
            enemyAI.enemyLife -= 1;
        }
        else
        {
            gameObject.SetActive(false);
            gameManager.enemySoloKilled += 1;
            enemyAI.islose = true;
        }
        _Cooldown = Max_Cooldown;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "OutMap")
        {
            Debug.Log("Hit");
            AIDead();
        }
    }

    public void spaw_AI()
    {
        enemyAI.EnemyHP = enemyAI.MaxHP;
        enemyAI.isDead = false;
        gameObject.transform.position = spawPoints[Random.Range(0, spawPoints.Length)].transform.position;
        isDaed = false;
    }
}
