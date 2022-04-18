using System;
using UnityEngine;
using UnityEngine.UI;
using YabbiAds.Api;
using YabbiAds.Common;


public class YabbiAdsDemo : MonoBehaviour, IInterstitialAdListener, IVideoAdListener
{
    public Text logger;
    public InputField pubIDField;
    public InputField interstitialIDField;
    public InputField videoIDField;
    


    private const string PubID = "INSERT_YOUR_ID";
    private const string InterstitialID = "INSERT_YOUR_ID";
    private const string VideoID = "INSERT_YOUR_ID";


    private void Start()
    {
        pubIDField.text = PubID;
        interstitialIDField.text = InterstitialID;
        videoIDField.text = VideoID;


        RestartContainers();
    }

    public void RestartContainers()
    {
        try
        {
            Destroy();

            Yabbi.Initialize(PubID);

            Yabbi.InitializeAd(InterstitialID, YabbiAdsType.Interstitial);
            Yabbi.InitializeAd(VideoID, YabbiAdsType.Video);
            Yabbi.SetInterstitialCallbacks(this);
            Yabbi.SetVideoCallbacks(this);

            WriteNewLog($"PubID: {PubID}\nInterstitialID: {InterstitialID}\nVideoID: {VideoID}");
        }
        catch (Exception e)
        {
            WriteNewLog($"{e}", false);
        }
    }

    private void Destroy()
    {
        Yabbi.DestroyAd(YabbiAdsType.Interstitial);
        Yabbi.DestroyAd(YabbiAdsType.Video);
    }


    public void StartInterstitialBanner()
    {
        WriteNewLog("InterstitialAdContainer | load");
        Yabbi.LoadAd(YabbiAdsType.Interstitial);
    }

    public void StartVideoBanner()
    {
        WriteNewLog("VideoAdContainer | load");
        Yabbi.LoadAd(YabbiAdsType.Video);
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
        WriteNewLog("InterstitialAdContainer | onLoad", false);
        Yabbi.ShowAd(YabbiAdsType.Interstitial);
    }

    public void OnInterstitialFailed(string error)
    {
        WriteNewLog($"InterstitialAdContainer | onFail | {error}", false);
    }

    public void OnInterstitialShown()
    {
        WriteNewLog($"InterstitialAdContainer | onShow", false);
    }

    public void OnInterstitialClosed()
    {
        WriteNewLog($"InterstitialAdContainer | onClose", false);
    }

    public void OnVideoLoaded()
    {
        WriteNewLog($"VideoAdContainer | onLoad", false);
        Yabbi.ShowAd(YabbiAdsType.Video);
    }

    public void OnVideoFailed(string error)
    {
        WriteNewLog($"VideoAdContainer | onFail | {error}", false);
    }

    public void OnVideoShown()
    {
        WriteNewLog($"VideoAdContainer | onShow", false);
    }

    public void OnVideoFinished()
    {
        WriteNewLog($"VideoAdContainer | onFinish", false);
    }

    public void OnVideoClosed()
    {
        WriteNewLog($"VideoAdContainer | onClose", false);
    }
}