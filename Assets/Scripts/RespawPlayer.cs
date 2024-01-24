using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    
   
    public Transform[] spawPoints;
    public Transform MyLocation;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "OutMap")
        {
            Debug.Log("Hit");
            spaw_Player();
        } 
    }
    //public void OnTriggerStay(Collider collider)
    //{
    //    if (collider.gameObject.tag == "OutMap")
    //    {
    //        Debug.Log("Hit");
    //        spaw_Player();
    //    }
    //}
    public void spaw_Player()
    {
        MyLocation.transform.position = spawPoints[Random.Range(0, spawPoints.Length)].transform.position;
        //MyLocation.transform.position = spawPoints;


    }
}
