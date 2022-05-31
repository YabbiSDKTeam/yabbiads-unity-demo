using System;
using YabbiAds.Common;
using YabbiAds.Platform.Factory;

namespace YabbiAds.Api
{
    public static class Yabbi
    {
        private static IYabbiAdsClient _client;

        private static IYabbiAdsClient GetInstance()
        {
            return _client ??= YabbiAdsClientFactory.GetYabbiAdsClient();
        }

        public static void Initialize(YabbiConfiguration configuration)
        {
            GetInstance().Initialize(configuration);
        }
        
        public static bool IsInitialized()
        {
           return GetInstance().IsInitialized();
        }
        

        public static bool CanLoadAd(int adType)
        {
            return GetInstance().CanLoadAd(adType);
        }

        public static void ShowAd(int adType)
        {
            GetInstance().ShowAd(adType);
        }

        public static bool IsAdLoaded(int adType)
        {
            return GetInstance().IsAdLoaded(adType);
        }

        public static void LoadAd(int adType)
        {
            GetInstance().LoadAd(adType);
        }
        
        [Obsolete("Method is deprecated, it will be removed in the next version and it doesn't work on android anymore.")]
        public static void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            GetInstance().SetAlwaysRequestLocation(adType, isEnabled);
        }

        public static void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            GetInstance().SetInterstitialCallbacks(adListener);
        }

        public static void SetRewardedCallbacks(IRewardedAdListener adListener)
        {
            GetInstance().SetRewardedCallbacks(adListener);
        }

        public static void DestroyAd(int adType)
        {
            GetInstance().DestroyAd(adType);
        }
    }
}