using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class playerSwimTime : MonoBehaviour
{
    public float timer = 0;
    private bool analyticSend = false;

    // Update is called once per frame
    void Update()
    {
        if(!analyticSend)
        {
            timer += Time.deltaTime;
        }

    }

    void SendAnalytic()
    {

        if(!analyticSend)
        {
            analyticSend = true;
            var data = new Dictionary<string, object>();
            data.Add("timePassed", timer);
            AnalyticsService.Instance.CustomData("playerEnterLab", data);
            AnalyticsService.Instance.Flush();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        SendAnalytic();
    }
}
