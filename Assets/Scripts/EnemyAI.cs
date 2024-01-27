using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : PlayerController
{
    [Header("Other")]
    NavMeshAgent agent;
    public List<GameObject> ListTarget;
    public GameObject player;
    public GameObject NearestOBJNearestOBJ;
    float distance;
    float nearestDistance = 10000;
    public Vector3 normalizedMovement;
    public float stopDistance;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        ListTarget.Add(player);
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (target != gameObject)
            {
                ListTarget.Add(target);
            }
        }

    }
        // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        normalizedMovement = agent.desiredVelocity.normalized;

        GameObject nearestObject = ListTarget[0];
        float distanceToNearest = Vector3.Distance(gameObject.transform.position, nearestObject.transform.position);
    
        for (int i = 0;i < ListTarget.Count;i++)
        {
            float distanceToCurrent = Vector3.Distance(gameObject.transform.position, ListTarget[i].transform.position);
        
            if(distanceToCurrent < distanceToNearest)
            {
                nearestObject = ListTarget[i];
                distanceToNearest = distanceToCurrent;
                
            }
        }
        NearestOBJNearestOBJ = nearestObject;

        float distanceTarget = Vector3.Distance(transform.position, NearestOBJNearestOBJ.transform.position);
        if (distanceTarget <= stopDistance)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
        agent.SetDestination(NearestOBJNearestOBJ.transform.position);

        anim.SetFloat("Horizontal", normalizedMovement.x);
        anim.SetFloat("Vertical", normalizedMovement.z);
        anim.SetFloat("Speed", normalizedMovement.sqrMagnitude);
    }
}
