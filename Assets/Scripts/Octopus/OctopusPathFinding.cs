using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OctopusPathFinding : MonoBehaviour
{
    private NavMeshAgent agent;
    [HideInInspector]public Animator animator;

    [SerializeField] private Transform start;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start(){
        agent.destination = start.position;
    }

    /// <summary>
    /// makes the octopus drop the item and stop moving
    /// </summary>
    public void giveUp(){
        animator.SetBool("walking", false);
        transform.LookAt(new Vector3(transform.position.x, -1, transform.position.z));
        GetComponent<ItemDrop>().DropItem();
    }

    /// <summary>
    /// function that changes target destination of nav agent
    /// </summary>
    /// <param name="next">transform point you want the agent to walk to</param>
    public void moveNext(Transform next){
        animator.SetBool("walking", true);
        agent.destination = next.position;
    }
}
