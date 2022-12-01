using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ValveManager : MonoBehaviour
{
    public UnityEvent EnoughValves;
    private int valves = 0;
    public void AddValve()
    {
        valves++;
        CheckValves();
    }

    public void RemoveValve()
    {
        valves--;
        CheckValves();
    }

    private void CheckValves()
    {
        if(valves >= 3)
        {
            EnoughValves.Invoke();
        }
    }
}
