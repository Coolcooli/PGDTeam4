using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CaptainStates{
    Idle, Walk
}
public class CaptainStatemachine : MonoBehaviour
{
    Vector3 lastPos;
    Animator animator;
    CaptainStates currentState = CaptainStates.Idle;


    void Start(){
        animator = GetComponent<Animator>();
    }
    void Update(){
        CaptainStates laststate = currentState;
        if(transform.position == lastPos){
            currentState = CaptainStates.Idle;
        }else{
            currentState = CaptainStates.Walk;
        }

        lastPos = transform.position;

        if(laststate == currentState)
            return;

        animator.SetInteger("state", (int)currentState);
        laststate = currentState;
    }
}
