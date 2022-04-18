using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Dummy
{
    public class DummyClient : IYabbiAdsClient
    {
        #region YabbiAds

        public void Initialize(string publisherId)
        {
            DebugLog("YabbiAds.initialize");
        }

        public void InitializeAd(string unitId, int adType)
        {
            DebugLog("YabbiAds.InitializeAdContainer");
        }

        public bool IsAdInitialized(int adType)
        {
            DebugLog("YabbiAds.isInitialized");
            return false;
        }

        public void ShowAd(int adType)
        {
            DebugLog("YabbiAds.show");
        }

        public bool IsAdLoaded(int adType)
        {
            DebugLog("YabbiAds.isLoaded");
            return false;
        }

        public void LoadAd(int adType)
        {
            DebugLog("YabbiAds.Load");
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            DebugLog("YabbiAds.SetAlwaysRequestLocation");
        }

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            DebugLog("YabbiAds.setInterstitialCallbacks");
        }

        public void SetVideoCallbacks(IVideoAdListener adListener)
        {
            DebugLog("YabbiAds.setVideoCallbacks");
        }

        public void DestroyAd(int adType)
        {
            DebugLog("YabbiAds.destroy");
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