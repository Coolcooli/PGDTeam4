using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChecker : MonoBehaviour
{
    public UnityEvent onTrigger;

    [SerializeField]
    private bool multiTriggerable = true;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(multiTriggerable)
        {
            onTrigger?.Invoke();
            triggered = true;
        }
        else if(!multiTriggerable && !triggered)
        {
            onTrigger?.Invoke();
            triggered = true;
        }
    }
}
