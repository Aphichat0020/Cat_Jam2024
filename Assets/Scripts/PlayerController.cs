using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    public Vector3 InputKey;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        InputKey = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        anim.SetFloat("Horizontal", InputKey.x);
        anim.SetFloat("Vertical", InputKey.z);
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector3) transform.position + InputKey * force * Time.deltaTime);
    }
}
