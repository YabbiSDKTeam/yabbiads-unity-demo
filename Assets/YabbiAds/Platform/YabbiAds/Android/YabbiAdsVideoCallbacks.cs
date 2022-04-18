using UnityEngine;
using YabbiAds.Common;

namespace YabbiAds.Platform.Android
{
    public class YabbiAdsVideoCallbacks
#if UNITY_ANDROID
        : AndroidJavaProxy
    {
        private readonly IVideoAdListener _listener;

        internal YabbiAdsVideoCallbacks(IVideoAdListener listener) : base(YabbiAdsConstants.YabbiAdEventsClassName)
        {
            _listener = listener;
        }

        private void onLoad() => _listener.OnVideoLoaded();

        private void onFail(string error) => _listener.OnVideoFailed(error);

        private void onShow() => _listener.OnVideoShown();

        public void onClose() => _listener.OnVideoClosed();

        public void onComplete() => _listener.OnVideoFinished();
    }
#else
    {
        public YabbiAdsVideoCallbacks(IVideoAdListener listener)
        {
        }
    }
#endif
}