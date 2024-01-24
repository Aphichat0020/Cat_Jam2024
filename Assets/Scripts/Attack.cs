using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Hitbox;
    public bool CanAttack;


    public void Start()
    {
       
    }
    void Update()
    {
        ClickMouseAttack();
    }

    public void ClickMouseAttack()
    {
        if(CanAttack == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(WaitCooldownAttack());
            }
        }
       
    }
    IEnumerator WaitCooldownAttack()
    {
        Hitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        CanAttack = false;
        Hitbox.SetActive(false);
        CanAttack = true;
    }
}
