using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Dummy
{
    public class DummyClient : IYabbiAdsClient
    {
        #region YabbiAds

        public void Initialize(YabbiConfiguration configuration)
        {
            DebugLog("YabbiAds.Initialize");
        }

        public bool IsInitialized()
        {
            DebugLog("YabbiAds.IsInitialized");
            return false;
        }

        public bool CanLoadAd(int adType)
        {
            DebugLog("YabbiAds.CanLoadAd");
            return false;
        }

        public void ShowAd(int adType)
        {
            DebugLog("YabbiAds.ShowAd");
        }

        public bool IsAdLoaded(int adType)
        {
            DebugLog("YabbiAds.isLoaded");
            return false;
        }

        public void LoadAd(int adType)
        {
            DebugLog("YabbiAds.LoadAd");
        }

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            DebugLog("YabbiAds.SetInterstitialCallbacks");
        }

        public void SetRewardedCallbacks(IRewardedAdListener adListener)
        {
            DebugLog("YabbiAds.SetRewardedCallbacks");
        }

        public void DestroyAd(int adType)
        {
            DebugLog("YabbiAds.DestroyAd");
        }

        #endregion

        #region Debug

        private static void DebugLog(string method)
        {
            Debug.Log(
                $"Call to {method} on not supported platform. To test advertising, install your application on the Android/iOS device.");
        }

        #endregion
    }
}