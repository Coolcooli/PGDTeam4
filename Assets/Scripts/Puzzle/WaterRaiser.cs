using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRaiser : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isRaising = false;

    [SerializeField]
    private float movementSpeed = 1f;

    [SerializeField]
    private float raiseAmount = .15f;

    private void FixedUpdate()
    {
        if (!isRaising) return;

        if (targetPosition.y - transform.position.y < 0.1f)
        {
            isRaising = false;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
    }

    public void StartRaise()
    {
        targetPosition = transform.position + raiseAmount * transform.up;
        isRaising = true;
    }
}
