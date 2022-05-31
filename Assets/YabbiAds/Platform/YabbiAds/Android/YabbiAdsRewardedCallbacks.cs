using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Android
{
    public class YabbiAdsRewardedCallbacks
    
#if UNITY_ANDROID
        : AndroidJavaProxy
        {
        private readonly IRewardedAdListener _listener;

        internal YabbiAdsRewardedCallbacks(IRewardedAdListener listener) : base(YabbiAdsConstants.YabbiAdsRewardedCallbacks)
        {
            _listener = listener;
        }

        private void onRewardedLoaded() => _listener.OnRewardedLoaded();

        private void onRewardedLoadFail(string error) => _listener.OnRewardedFailed(error);

        private void onRewardedShown() => _listener.OnRewardedShown();

        private void onRewardedShowFailed(string error) => _listener.OnRewardedFailed(error);

        public void onRewardedClosed() => _listener.OnRewardedClosed();

        public void onRewardedFinished() => _listener.OnRewardedFinished();
    }
#else
    {
        public YabbiAdsRewardedCallbacks(IRewardedAdListener listener)
        {
        }
    }
#endif
}