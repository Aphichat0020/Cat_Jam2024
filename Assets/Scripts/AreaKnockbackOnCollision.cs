using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaKnockbackOnCollision : MonoBehaviour
{
    public string enemyTag;
    public PlayerController playerController;
    public GameObject player;
    private float KnockbackStrength;
    private float KnockbackRadius;
    private float playerDamage;
    NavMeshAgent agent;
    
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
            playerDamage = playerController.totalPlayerDamage;
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

            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag ==  enemyTag)
            {

                Rigidbody rb = collision.GetComponent<Rigidbody>();

                if (rb != null)
                {

                    print(collision.gameObject.name);
                    if (rb.tag == enemyTag || rb.tag == "Enemy")
                    {
                        if (rb.tag == "Enemy")
                        {
                            collision.gameObject.GetComponent<NavMeshAgent>().velocity = playerController.InputKey * KnockbackStrength * 0.4f;
                            print(collision.gameObject.GetComponent<NavMeshAgent>().velocity);
                            //StartCoroutine(collision.gameObject.GetComponent<EnemyAI>().GetHit());
                            
                            collision.gameObject.GetComponent<EnemyAI>().GetHit(playerDamage);
                            
                        }

                        rb.AddExplosionForce(KnockbackStrength, player.transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
                        print(collision.gameObject.GetComponent<Rigidbody>().velocity);

                        if(rb.tag == enemyTag)
                        {
                            collision.gameObject.GetComponent<PlayerController>().GetHit(playerDamage);
                        }
                    }

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
