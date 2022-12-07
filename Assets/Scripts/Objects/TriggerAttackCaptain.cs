using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAttackCaptain : MonoBehaviour
{
    public UnityEvent onStartFishAttack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Captain"))
        {
            onStartFishAttack?.Invoke();
        }
    }
}
