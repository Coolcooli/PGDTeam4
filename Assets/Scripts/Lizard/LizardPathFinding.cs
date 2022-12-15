using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LizardPathFinding : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform goal;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start(){
        agent.destination = goal.position;
    }

    public void moveNext(Transform next){
        agent.destination = next.position;
    }
}
