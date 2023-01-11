using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private bool move = false;

    private float origin;

    private void Start()
    {
        origin = transform.position.y;
    }
    private void Update()
    {
        if (!move)
            return;

        if(transform.position.y < origin + 10)
        {
            transform.position += -transform.up*0.01f;
        }
    }
    public void StartMove()
    {
        move = true;
    }
}
