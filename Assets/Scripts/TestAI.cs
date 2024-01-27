using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform MovePositionTransform;
    public NavMeshAgent agent;
    public float Distane_AI;
    public float BetweenAI;
    public float RangAI_Attack;
    public float RangAI_RandomWalkDistance;
    Vector3 pointToMove;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
    }
    void Start()
    {
        pointToMove = GetRandomPointOnNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //float distanceTarget = Vector3.Distance(transform.position, pointToMove);

        //if (distanceTarget <= 2)
        //{
        //    agent.isStopped = true;
        //    pointToMove = GetRandomPointOnNavMesh();
        //}
        //else
        //{
        //   agent.SetDestination(pointToMove);
        //    agent.isStopped = false;
        //}


        //////////////

        agent.SetDestination(MovePositionTransform.position);
        BetweenAI = Vector3.Distance(transform.position, MovePositionTransform.position);
       
        if (Vector3.Distance(transform.position,MovePositionTransform.position) < RangAI_Attack)
        {
           
            agent.SetDestination(transform.position);
           
        }
        else
        {
            agent.SetDestination(MovePositionTransform.position);
          
        }
       

    }
    Vector3 GetRandomPointOnNavMesh()
    {
       NavMeshHit hit;
       Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * RangAI_RandomWalkDistance;

        if (NavMesh.SamplePosition(randomPoint, out hit, RangAI_RandomWalkDistance, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return transform.position;
    }




}
