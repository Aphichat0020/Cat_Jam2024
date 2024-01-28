using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
    public PlayerController player;
    public int playerLife;
    public float playerHP;
    public Image HpBar;
    public List<GameObject> heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLife == 9)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(true);
            heart[4].SetActive(true);
            heart[5].SetActive(true);
            heart[6].SetActive(true);
            heart[7].SetActive(true);
            heart[8].SetActive(true);
        }
        else if (playerLife == 8)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(true);
            heart[4].SetActive(true);
            heart[5].SetActive(true);
            heart[6].SetActive(true);
            heart[7].SetActive(true);
            heart[8].SetActive(false);
        }
        else if (playerLife == 7)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(true);
            heart[4].SetActive(true);
            heart[5].SetActive(true);
            heart[6].SetActive(true);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 6)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(true);
            heart[4].SetActive(true);
            heart[5].SetActive(true);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 5)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(true);
            heart[4].SetActive(true);
            heart[5].SetActive(false);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 4)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(true);
            heart[4].SetActive(false);
            heart[5].SetActive(false);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 3)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(true);
            heart[3].SetActive(false);
            heart[4].SetActive(false);
            heart[5].SetActive(false);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 2)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(true);
            heart[2].SetActive(false);
            heart[3].SetActive(false);
            heart[4].SetActive(false);
            heart[5].SetActive(false);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 1)
        {
            heart[0].SetActive(true);
            heart[1].SetActive(false);
            heart[2].SetActive(false);
            heart[3].SetActive(false);
            heart[4].SetActive(false);
            heart[5].SetActive(false);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }
        else if (playerLife == 0)
        {
            heart[0].SetActive(false);
            heart[1].SetActive(false);
            heart[2].SetActive(false);
            heart[3].SetActive(false);
            heart[4].SetActive(false);
            heart[5].SetActive(false);
            heart[6].SetActive(false);
            heart[7].SetActive(false);
            heart[8].SetActive(false);
        }

        playerLife = player.playerLife;
        playerHP = player.playerHP;

        HpBar.fillAmount = playerHP / 100;
    }
}
