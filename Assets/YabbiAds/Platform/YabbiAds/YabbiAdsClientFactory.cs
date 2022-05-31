using YabbiAds.Common;
#if UNITY_ANDROID
using YabbiAds.Platform.Android;
#elif UNITY_IPHONE
using YabbiAds.Platform.iOS;
#else
using YabbiAds.Platform.Dummy;
#endif


namespace YabbiAds.Platform.Factory
{
    internal static class YabbiAdsClientFactory
    {
        internal static IYabbiAdsClient GetYabbiAdsClient()
        {
#if UNITY_ANDROID
			return new AndroidYabbiAdsClient();
#elif UNITY_IPHONE
			return IOSYabbiAdsClient.Instance;
#else
            return new DummyClient();
#endif
        }
    }
}