using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CaptainStates
{
    Idle, Walk
}
public class CaptainStatemachine : MonoBehaviour
{
    private Vector3 lastPos;
    private Animator animator;
    private CaptainStates currentState = CaptainStates.Idle;
    private CaptainStates lastState = CaptainStates.Idle;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        lastState = currentState;
        if (transform.position == lastPos)
        {
            currentState = CaptainStates.Idle;
        }
        else
        {
            currentState = CaptainStates.Walk;
        }

        lastPos = transform.position;

        if (lastState == currentState)
            return;

        animator.SetInteger("state", (int)currentState);
        lastState = currentState;
    }
}
