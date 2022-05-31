using System;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using YabbiAds.Api;
using YabbiAds.Common;


public class YabbiAdsDemo : MonoBehaviour, IInterstitialAdListener, IRewardedAdListener
{
    public Text logger;
    public InputField pubIDField;
    public InputField interstitialIDField;
    public InputField videoIDField;
    


    private const string PubID = "INSERT_YOUR_ID";
    private const string InterstitialID = "INSERT_YOUR_ID";
    private const string RewardedID = "INSERT_YOUR_ID";


    private void Start()
    {
        pubIDField.text = PubID;
        interstitialIDField.text = InterstitialID;
        videoIDField.text = RewardedID;


        RestartContainers();
    }

    public void RestartContainers()
    {
        try
        {
            Destroy();

            var configuration = new YabbiConfiguration(PubID, InterstitialID, RewardedID);
            Yabbi.Initialize(configuration);
            Yabbi.SetInterstitialCallbacks(this);
            Yabbi.SetRewardedCallbacks(this);

            WriteNewLog($"PubID: {PubID}\nInterstitialID: {InterstitialID}\nRewardedID: {RewardedID}");
        }
        catch (Exception e)
        {
            WriteNewLog($"{e}", false);
        }
    }

    private void Destroy()
    {
        Yabbi.DestroyAd(YabbiAdsType.Interstitial);
        Yabbi.DestroyAd(YabbiAdsType.Rewarded);
    }


    public void StartInterstitialBanner()
    {
        Yabbi.LoadAd(YabbiAdsType.Interstitial);
        WriteNewLog("InterstitialAd | load");
    }

    public void StartRwardedBanner()
    {
        Yabbi.LoadAd(YabbiAdsType.Rewarded);
        WriteNewLog("RewardedAd | load");

    }

    private void WriteNewLog(string message, bool restart = true)
    {
        if (restart)
        {
            logger.text = message;
        }
        else
        {
            var current = logger.text;
            logger.text = $"{current}\n{message}";
        }
    }

    public void OnInterstitialLoaded()
    {
        WriteNewLog("OnInterstitialLoaded", false);
        Yabbi.ShowAd(YabbiAdsType.Interstitial);
    }

    public void OnInterstitialFailed(string error)
    {
        WriteNewLog($"OnInterstitialFailed: {error}", false);
    }

    public void OnInterstitialShown()
    {
        WriteNewLog($"OnInterstitialShown", false);
    }

    public void OnInterstitialClosed()
    {
        WriteNewLog($"OnInterstitialClosed", false);
    }

    public void OnRewardedLoaded()
    {
        WriteNewLog($"OnRewardedLoaded", false);
        Yabbi.ShowAd(YabbiAdsType.Rewarded);
    }

    public void OnRewardedFailed(string error)
    {
        WriteNewLog($"OnRewardedFailed: {error}", false);
    }

    public void OnRewardedShown()
    {
        WriteNewLog($"OnRewardedShown", false);
    }

    public void OnRewardedFinished()
    {
        WriteNewLog($"OnRewardedFinished", false);
    }

    public void OnRewardedClosed()
    {
        WriteNewLog($"OnRewardedClosed", false);
    }
}