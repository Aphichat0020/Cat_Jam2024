using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBoxSpawner : MonoBehaviour
{
    public List<Transform> spawnPoint;
    public GameObject boxPrefab;
    PlayerBuffHolder.BuffName buffName;
    public SpawnPoint[] AllBuffSpawnPoint;
    public List<GameObject> AllBox;
    public float MaxTimer = 15f;
    public float timer;
    bool check;
    public bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        timer = MaxTimer;
        AllBuffSpawnPoint = GetComponentsInChildren<SpawnPoint>();
        //SpawnBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            AllBox = new List<GameObject>();
            foreach (GameObject buff in GameObject.FindGameObjectsWithTag("BuffBox"))
            {
                AllBox.Add(buff);
            }

            if (AllBox.Count <= 1)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {

                    if (!check)
                    {
                        for (int i = 0; i < AllBox.Count; i++)
                        {
                            Destroy(AllBox[i]);
                        }
                        check = true;
                    }
                    else
                    {
                        SpawnBox();
                        timer = MaxTimer;
                    }

                }
            }
        }
        
    }

    public void RandomBuff()
    {
        int buffRandom = Random.Range(0, 3);
        if (buffRandom == 0)
        {
            buffName = PlayerBuffHolder.BuffName.Speed;
        }
        else if(buffRandom == 1)
        {
            buffName = PlayerBuffHolder.BuffName.Knockback;
        }
        else if (buffRandom == 2)
        {
            buffName = PlayerBuffHolder.BuffName.Giant;
        }
        else if (buffRandom == 3)
        {
            buffName = PlayerBuffHolder.BuffName.God;
        }
    }

    public void SpawnBox()
    {
        for (int i = 0; i < spawnPoint.Count; i++)
        {
            if (!AllBuffSpawnPoint[i].hasBox)
            {
                RandomBuff();
                GameObject boxObj = Instantiate(boxPrefab, AllBuffSpawnPoint[i].transform.position, Quaternion.identity);
                AllBuffSpawnPoint[i].hasBox = true;
                boxObj.GetComponent<BuffBox>().buffName = buffName;
                boxObj.GetComponent<BuffBox>().spawnPoint = AllBuffSpawnPoint[i];
            }
        }
        timer = 15f;
    }
}
