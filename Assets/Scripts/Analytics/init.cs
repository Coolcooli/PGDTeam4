using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Collections.Generic;
using UnityEngine.Analytics;
using Unity.Services.Core.Analytics;

public class Init : MonoBehaviour
{
    async void Awake()
    {
        try
        {

            string newUserId = Random.Range(11111111, 99999999).ToString();
            var options = new InitializationOptions();
            options.SetAnalyticsUserId(newUserId);

            await UnityServices.InitializeAsync(options);
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
            Debug.Log("init error");
        }
    }
}