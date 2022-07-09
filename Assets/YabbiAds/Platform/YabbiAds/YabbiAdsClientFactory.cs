using YabbiAds.Common;
#if UNITY_ANDROID && !UNITY_EDITOR
using YabbiAds.Platform.Android;
#elif UNITY_IPHONE && !UNITY_EDITOR
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
#if UNITY_ANDROID && !UNITY_EDITOR
			return new AndroidYabbiAdsClient();
#elif UNITY_IPHONE && !UNITY_EDITOR
			return IOSYabbiAdsClient.Instance;
#else
            return new DummyClient();
#endif
        }
    }
}