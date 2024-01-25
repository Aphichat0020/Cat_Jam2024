using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawBuff : MonoBehaviour
{
    public Transform[] PositionBuff;
    public GameObject[] ObjectBuff;

    public GameObject IsBuffinGameNow;

    public float TimeChangBuff;
   // private Transform LocationBuff;
    void Start()
    {
       
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Spaw_Buff();
        }
    }
    public void Spaw_Buff()
    {
        // PositionBuff = PositionBuff[Random.Range(0, PositionBuff.Length)];
        IsBuffinGameNow = Instantiate(ObjectBuff[Random.Range(0, ObjectBuff.Length)],PositionBuff[Random.Range(0, PositionBuff.Length)]);
      // StartCoroutine(TimeDestroyBuff());
    }
    public void GetBuff()
    {
        Destroy(IsBuffinGameNow);
        //Player have buff
        // 
    }
    IEnumerator TimeDestroyBuff()
    {
        yield return new WaitForSeconds(TimeChangBuff);
        Destroy(IsBuffinGameNow);
       // Spaw_Buff();
    }

}
