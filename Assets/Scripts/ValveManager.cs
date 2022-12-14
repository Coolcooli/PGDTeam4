using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class ValveManager : MonoBehaviour
{
    public UnityEvent enoughValves;
    private int valves = 0;
    private int totalTimesToggled;
    private bool activated, sendAnalytics;


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
            enoughValves.Invoke();
        }
    }

    public void IncreaseToggle()
    {
        if(!activated)
        {
            activated = true;
            StartCoroutine(increaseToggle());
        }
    }

    IEnumerator increaseToggle()
    {
        totalTimesToggled++;
        yield return new WaitForSeconds(3f);
        activated = false;
    }

    public void SendAnalytics()
    {
        if (sendAnalytics) return;
        sendAnalytics = true;
        var data = new Dictionary<string, object>();
        data.Add("timesDoorToggled", totalTimesToggled);
        AnalyticsService.Instance.CustomData("mainLabDoorToggles", data);
        AnalyticsService.Instance.Flush();
    }



}
