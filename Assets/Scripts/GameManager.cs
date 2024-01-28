using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject soloPlayerScene;
    public GameObject coopPlayerScene;

    public GameObject player_Win_Solo;
    public GameObject player_Lose_Solo;
    public GameObject player_P1_solo;

    public GameObject player_P1Win_Coop;
    public GameObject player_P2Win_Coop;
    public GameObject player_P1Lose_Coop;
    public GameObject player_P2Lose_Coop;

    public GameObject player_P1_coop;
    public GameObject player_P2_coop;

    public GameObject cam01;
    public GameObject cam02;

    public List<GameObject> soloEnemyList;
    public List<GameObject> coopEnemyList;

    public float MaxtimerBeforeStartGame;
    float timer;
    public bool startSolo;
    public bool startCoop;

    public bool WinSolo;
    public bool WinCoop;

    bool Checksolo;
    bool CheckCoop;

    public int enemySoloKilled;
    public int enemyCoopKilled;
    public BuffBoxSpawner buffBoxSpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySoloKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckSoloPlayer();
        

        if (startSolo)
        {
            if (!Checksolo)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    StartSoloScene();
                    Checksolo = true;
                }
            }
        }

        if (startCoop)
        {
            if (!CheckCoop)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    StartCoopScene();
                    CheckCoop = true;
                }
            }
        }
    }

    public void ActiveSoloScene()
    {
        soloPlayerScene.SetActive(true);
        coopPlayerScene.SetActive(false);
        startSolo = true;
        startCoop = false;
        timer = MaxtimerBeforeStartGame;
    }

    public void StartSoloScene()
    {
        buffBoxSpawner.isStart = true;
        for (int i = 0; i < soloEnemyList.Count; i++)
        {
            soloPlayerScene.SetActive(true);
            cam01.GetComponent<CameraFollows>().player = player_P1_solo.transform;
        }
    }

    public void ActiveCoopScene()
    {
        soloPlayerScene.SetActive(false);
        coopPlayerScene.SetActive(true);
        startSolo = false;
        startCoop = true;
        timer = MaxtimerBeforeStartGame;
    }

    public void StartCoopScene()
    {
        buffBoxSpawner.isStart = true;
        for (int i = 0; i < coopEnemyList.Count; i++)
        {
            coopPlayerScene.SetActive(true);
            cam02.SetActive(true );
            cam01.GetComponent<CameraFollows>().player = player_P1_coop.transform;
            cam02.GetComponent<CameraFollows>().player = player_P2_coop.transform;
        }
    }

    public void CheckSoloPlayer()
    {
        if (ModeManager.instance.is_Solo)
        {

            if (enemySoloKilled >= 5)
            {
                P1WinGameSolo();
                WinSolo = true;
            }
            else
            {
                WinSolo = false;
            }
            
        }
        else if(ModeManager.instance.is_Online)
        {

            if (enemyCoopKilled >= 4)
            {
                if (player_P2_coop.GetComponent<PlayerController>().islose)
                {
                    P1WinGameCoop();
                }
                else if (player_P1_coop.GetComponent<PlayerController>().islose)
                {
                    P2WinGameCoop();
                }
            }
            
        }
    }

    public void P1WinGameSolo()
    {
        player_Win_Solo.SetActive(true);
    }
    public void P1WinGameCoop()
    {
        player_P1Win_Coop.SetActive(true);
    }

    public void P2WinGameCoop()
    {
        player_P2Win_Coop.SetActive(true);
    }

    public void P1LoseGameSolo()
    {
        player_Lose_Solo.SetActive(false);
    }
    public void P1LoseGameCoop()
    {
        player_P1Lose_Coop.SetActive(false);
    }

    public void P2LoseGameCoop()
    {
        player_P2Lose_Coop.SetActive(false);
    }
}
