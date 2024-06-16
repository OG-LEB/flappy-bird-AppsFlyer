using UnityEngine;
using AppsFlyerSDK;
using System.Collections.Generic;

public class AppsFlyerScript : MonoBehaviour, IAppsFlyerConversionData
{
    private UIController _UIController;
    private Dictionary<string, object> _ConversionData;
    private string output = "";
    private void Start()
    {
        _UIController = GetComponent<UIController>();
        Debug.Log("SDK initialisation");
        AppsFlyer.setIsDebug(true);
        string devKey = "ZLigGqGzDdxGMT7QBPjsMG";
        string appId = "com.testtask.flappybird";
        AppsFlyer.initSDK(devKey, appId, this);
        AppsFlyer.startSDK();
        Debug.Log("SDK started");

    }
    public void onAppOpenAttribution(string attributionData)
    {
        Debug.Log("Open attribution: " + attributionData);
    }

    public void onAppOpenAttributionFailure(string error)
    {
        Debug.LogError("Open attribution Failure: " + error);
    }

    public void onConversionDataFail(string error)
    {
        Debug.LogError("Conversion Data Failure: " + error);
        _UIController.OpenConversionDataWin(error);

    }

    public void onConversionDataSuccess(string conversionData)
    {
        Debug.Log("ConversionDataSuccess!");
        AppsFlyer.AFLog("onConversionDataSuccess", conversionData);
        _ConversionData = AppsFlyer.CallbackStringToDictionary(conversionData);

        foreach (KeyValuePair<string, object> kvp in _ConversionData)
        {
            output += $"Key: {kvp.Key}, Value: {kvp.Value}; ";
        }
        _UIController.OpenConversionDataWin(output);
    }
}
