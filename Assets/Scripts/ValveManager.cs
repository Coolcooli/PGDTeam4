using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ValveManager : MonoBehaviour
{
    public UnityEvent enoughValves;
    [SerializeField]
    private int valves = 0;

    public void AddValve()
    {
        valves++;
        CheckValves();
    }

    public void RemoveValve()
    {
        valves--;
    }

    private void CheckValves()
    {
        if(valves >= 3)
        {
            enoughValves.Invoke();
        }
    }
}
