using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnCollision : MonoBehaviour
{
    [SerializeField]
    private float KnockbackStrength;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
        if(rb != null)
        {
            Vector3 direction = collision.transform.position - transform.forward;
            direction.y = 0f;
            rb.AddForce(direction.normalized * KnockbackStrength , ForceMode.Impulse);
        }
    }
}
