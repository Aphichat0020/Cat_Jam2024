using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditorInternal;
using UnityEngine;

public class RespawPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float Max_Cooldown;
    public float _Cooldown;
    public bool isDie = false;
   
    public Transform[] spawPoints;
    public Transform MyLocation;

    Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    public void Update()
    {
        if (isDie)
        {
           
            _Cooldown -= Time.deltaTime;

            if (_Cooldown <= 0)
            {
                _Cooldown = 0;
                
                spaw_Player();
            }
        }
       
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "OutMap")
        {
            Debug.Log("Hit");
           // spaw_Player();
            Cooldown_SpawPlayer();
        } 
    }
   
    public void spaw_Player()
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = true;
        rb.isKinematic = false;
        MyLocation.transform.position = spawPoints[Random.Range(0, spawPoints.Length)].transform.position;
        //MyLocation.transform.position = spawPoints;
        isDie = false;


    }
    public void Cooldown_SpawPlayer()
    {
        isDie = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;

        _Cooldown = Max_Cooldown;
    }
}
