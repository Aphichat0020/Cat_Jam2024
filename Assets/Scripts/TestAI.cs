using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform MovePositionTransform;
    public NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = MovePositionTransform.position;
    }
}
