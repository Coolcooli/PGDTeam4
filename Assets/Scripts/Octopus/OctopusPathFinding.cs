using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OctopusPathFinding : MonoBehaviour
{
    private NavMeshAgent agent;
    public Animator animator;
    [SerializeField] private Transform goal;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start(){
        agent.destination = goal.position;
    }

    public void moveNext(Transform next){
        animator.SetBool("walking", true);
        agent.destination = next.position;
    }
}
