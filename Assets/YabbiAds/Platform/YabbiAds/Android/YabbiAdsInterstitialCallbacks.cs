using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Android
{
    public class YabbiAdsInterstitialCallbacks
#if UNITY_ANDROID
        : AndroidJavaProxy
    {
        private readonly IInterstitialAdListener _listener;

        internal YabbiAdsInterstitialCallbacks(IInterstitialAdListener listener) : base(YabbiAdsConstants
            .YabbiAdEventsClassName)
        {
            _listener = listener;
        }

        private void onLoad() => _listener.OnInterstitialLoaded();

        private void onFail(string error) => _listener.OnInterstitialFailed(error);

        private void onShow() => _listener.OnInterstitialShown();

        public void onClose() => _listener.OnInterstitialClosed();
    }
#else
    {
        public YabbiAdsInterstitialCallbacks(IInterstitialAdListener listener)
        {
        }
    }
#endif
}