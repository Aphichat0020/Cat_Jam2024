using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaKnockbackOnCollision : MonoBehaviour
{
    [SerializeField]
    private float KnockbackStrength;
    [SerializeField]
    private float KnockbackRadius;

    public void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, KnockbackRadius);
        for (int i = 0;i<colliders.Length; i++)
        {

            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();  

            if (rb != null)
            {
                rb.AddExplosionForce(KnockbackStrength,transform.position, KnockbackRadius ,0f ,ForceMode.Impulse);
            }
        }

    }
    public void OnTriggerEnter(Collider collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, KnockbackRadius);
        for (int i = 0; i < colliders.Length; i++)
        {

            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(KnockbackStrength, transform.position, KnockbackRadius, 0f, ForceMode.Impulse);
            }
        }
    }
}
