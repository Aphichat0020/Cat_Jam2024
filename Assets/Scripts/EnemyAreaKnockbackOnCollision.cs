using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAreaKnockbackOnCollision : MonoBehaviour
{
    public EnemyAI enemyController;
    public GameObject enemy;
    private float KnockbackStrength;
    private float KnockbackRadius;

    public void Start()
    {
        enemyController = gameObject.GetComponentInParent<EnemyAI>();
    }
    public void Update()
    {
        if (enemyController)
        {
            KnockbackStrength = enemyController.totalKnockbackStrength;
            KnockbackRadius = enemyController.totalKnockbackRadius_AOE;
        }
        else
        {
            enemyController.GetComponentInParent<EnemyAI>();
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
        if (enemyController.isAOE_Attack)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, KnockbackRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody rb = colliders[i].GetComponent<Rigidbody>();

                if (rb != null)
                {
                    if (rb.tag == "Player" || rb.tag == "Enemy")

                    {
                        print(rb.name);
                        rb.AddExplosionForce(KnockbackStrength, enemy.transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
                       // StartCoroutine(ResetVelocity(rb));
                    }
                }
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
            {

                Rigidbody rb = collision.GetComponent<Rigidbody>();

                if (rb != null)
                {

                    
                    if (rb.tag == "Player" || rb.tag == "Enemy")
                    {

                      // StartCoroutine(ResetVelocity(rb));
                    }
                    rb.AddExplosionForce(KnockbackStrength, enemy.transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
                    print(collision.gameObject.GetComponent<Rigidbody>().velocity);
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
