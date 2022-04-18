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

        public static void Initialize(string publisherID)
        {
            GetInstance().Initialize(publisherID);
        }

        public static void InitializeAd(string unitID, int adType)
        {
            GetInstance().InitializeAd(unitID, adType);
        }

        public static bool IsAdInitialized(int adType)
        {
            return GetInstance().IsAdInitialized(adType);
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

        public static void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            GetInstance().SetAlwaysRequestLocation(adType, isEnabled);
        }

        public static void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            GetInstance().SetInterstitialCallbacks(adListener);
        }

        public static void SetVideoCallbacks(IVideoAdListener adListener)
        {
            GetInstance().SetVideoCallbacks(adListener);
        }

        public static void DestroyAd(int adType)
        {
            GetInstance().DestroyAd(adType);
        }
    }
}