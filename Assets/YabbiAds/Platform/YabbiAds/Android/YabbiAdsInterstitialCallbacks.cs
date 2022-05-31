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
            .YabbiAdsInterstitialCallbacks)
        {
            _listener = listener;
        }

        private void onInterstitialLoaded() => _listener.OnInterstitialLoaded();

        private void onInterstitialLoadFail(string error) => _listener.OnInterstitialFailed(error);

        private void onInterstitialShowFailed(string error) => _listener.OnInterstitialFailed(error);

        private void onInterstitialShown() => _listener.OnInterstitialShown();

        public void onInterstitialClosed() => _listener.OnInterstitialClosed();
    }
#else
    {
        public YabbiAdsInterstitialCallbacks(IInterstitialAdListener listener)
        {
        }
    }
#endif
}