#if UNITY_ANDROID && !UNITY_EDITOR
using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Android
{
    public class AndroidYabbiAdsClient : IYabbiAdsClient
    {
        private AndroidJavaObject _activity;


        private AndroidJavaClass _yabbiAdsClass;

        private AndroidJavaClass GetYabbiAdsClass()
        {
            return _yabbiAdsClass ??= new AndroidJavaClass(YabbiAdsConstants.YabbiAds);
        }

        public void Initialize(YabbiConfiguration configuration)
        {
            var  androidConfig =new AndroidJavaObject(YabbiAdsConstants.YabbiConfiguration,
                configuration.PublisherID,  configuration.InterstitialID, configuration.RewardedID);
            GetYabbiAdsClass().CallStatic("initialize", androidConfig);
        }

        public bool IsInitialized()
        {
           return GetYabbiAdsClass().CallStatic<bool>("isInitialized");
        }

        private AndroidJavaObject GetActivity()
        {
            if (_activity != null) return _activity;
            var playerClass = new AndroidJavaClass(YabbiAdsConstants.UnityActivityClassName);
            _activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");

            return _activity;
        }

        private static AndroidJavaObject BoolToAndroid(bool value)
        {
            var boleanClass = new AndroidJavaClass("java.lang.Boolean");
            var boolean = boleanClass.CallStatic<AndroidJavaObject>("valueOf", value);
            return boolean;
        }

        public bool CanLoadAd(int adType)
        {
            return GetYabbiAdsClass().CallStatic<bool>("canLoadAd", adType);
        }

        public void ShowAd(int adType)
        {
            GetYabbiAdsClass().CallStatic("showAd",GetActivity(), adType);
        }

        public bool IsAdLoaded(int adType)
        {
            return GetYabbiAdsClass().CallStatic<bool>("isAdLoaded", adType);
        }

        public void LoadAd(int adType)
        {
             GetYabbiAdsClass().CallStatic("loadAd",GetActivity(), adType);
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled) {}
        
        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            GetYabbiAdsClass().CallStatic("setInterstitialCallbacks", new YabbiAdsInterstitialCallbacks(adListener));
        }

        public void SetRewardedCallbacks(IRewardedAdListener adListener)
        {
            GetYabbiAdsClass().CallStatic("setRewardedCallbacks", new YabbiAdsRewardedCallbacks(adListener));
        }

        public void DestroyAd(int adType)
        {
            GetYabbiAdsClass().CallStatic("destroyAd", adType);
        }
    }
}
#endif