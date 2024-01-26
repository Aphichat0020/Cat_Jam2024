using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaKnockbackOnCollision : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject player;
    private float KnockbackStrength;
    private float KnockbackRadius;

    public void Start()
    {
        playerController= gameObject.GetComponentInParent<PlayerController>();
    }
    public void Update()
    {
        if (playerController)
        {
            KnockbackStrength = playerController.totalKnockbackStrength;
            KnockbackRadius = playerController.totalKnockbackRadius_AOE;
        }
        else
        {
            playerController.GetComponentInParent<PlayerController>();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, KnockbackRadius);
            for (int i = 0; i < colliders.Length; i++)
            {

                Rigidbody rb = colliders[i].GetComponent<Rigidbody>(); 
                if (rb != null)
                {
                    rb.AddExplosionForce(KnockbackStrength, transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
                  //  StartCoroutine(ResetVelocity(rb));
                }

            }
        }

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (playerController.isAOE_Attack)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, KnockbackRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody rb = colliders[i].GetComponent<Rigidbody>();

                if (rb != null)
                {
                    if (rb.tag != "Player")
                    {
                        print(rb.name);
                        rb.AddExplosionForce(KnockbackStrength, player.transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
                       // StartCoroutine(ResetVelocity(rb));
                    }
                }
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy")
            {

                Rigidbody rb = collision.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    if (rb.tag != "Player")
                    {
                     
                     
                      // StartCoroutine(ResetVelocity(rb));
                    }
                    rb.AddExplosionForce(KnockbackStrength, player.transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
                    print(rb.name);
                }
            }
        }
    }
  
    IEnumerator ResetVelocity(Rigidbody rb)
    {
        yield return new WaitForSeconds(1);
        rb.velocity = Vector3.zero;
    }
}
