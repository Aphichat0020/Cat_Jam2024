using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBox : MonoBehaviour
{
    public PlayerBuffHolder playerBuffHolder;
    public EnemyBuffHolder enemyBuffHolder;
    public PlayerBuffHolder.BuffName buffName;
    public SpawnPoint spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GivePlayerBuff(PlayerBuffHolder.BuffName buff)
    {
        playerBuffHolder.PlayerGetBuff(buff);
        spawnPoint.hasBox = false;
        Destroy(gameObject);
    }

    public void GiveEnemyBuff(PlayerBuffHolder.BuffName _buff)
    {
        enemyBuffHolder.EnemyGetBuff(_buff);
        spawnPoint.hasBox = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print(other.gameObject.name);
            playerBuffHolder =other.gameObject.GetComponent<PlayerBuffHolder>();
            if (playerBuffHolder.curretBuff == PlayerBuffHolder.BuffName.None)
            {
                GivePlayerBuff(buffName);
            }
        }
        else if(other.gameObject.tag == "Player2")
        {
            print(other.gameObject.name);
            playerBuffHolder = other.gameObject.GetComponent<PlayerBuffHolder>();
            if (playerBuffHolder.curretBuff == PlayerBuffHolder.BuffName.None)
            {
                GivePlayerBuff(buffName);
            }
        }
        else if (other.gameObject.tag == "Enemy")
        {
            enemyBuffHolder = other.gameObject.GetComponent<EnemyBuffHolder>();
            if (enemyBuffHolder.curretBuff == PlayerBuffHolder.BuffName.None)
            {
                GiveEnemyBuff(buffName);
            }
        }
    }
}
