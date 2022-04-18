#if UNITY_IPHONE || UNITY_EDITOR
using AOT;
using YabbiAds.Common;

namespace YabbiAds.Platform.iOS
{
    public class IOSYabbiAdsClient : IYabbiAdsClient
    {
        #region Singleton

        private IOSYabbiAdsClient()
        {
        }

        public static IOSYabbiAdsClient Instance { get; } = new IOSYabbiAdsClient();

        #endregion


        private static IInterstitialAdListener _interstitialAdListener;
        private static IVideoAdListener _videoAdListener;


        public void Initialize(string publisherID)
        {
            YabbiAdsObjCBridge.YabbiInitialize(publisherID);
        }

        public void InitializeAd(string unitID, int type)
        {
            YabbiAdsObjCBridge.YabbiInitializeAd(unitID, type);
        }

        public bool IsAdInitialized(int adType)
        {
            return YabbiAdsObjCBridge.YabbiIsAdInitialized(adType);
        }

        public void ShowAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiShowAd(adType);
        }

        public bool IsAdLoaded(int adType)
        {
            return YabbiAdsObjCBridge.YabbiIsAdLoaded(adType);
        }

        public void LoadAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiLoadAd(adType);
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            YabbiAdsObjCBridge.YabbiSetAlwaysRequestLocation(adType, isEnabled);
        }

        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            _interstitialAdListener = adListener;
            YabbiAdsObjCBridge.YabbiSetInterstitialDelegate(
                OnInterstitialLoaded,
                OnInterstitialShown,
                OnVideoClosed,
                OnInterstitialFailed
            );
        }

        public void SetVideoCallbacks(IVideoAdListener adListener)
        {
            _videoAdListener = adListener;
            YabbiAdsObjCBridge.YabbiSetVideoDelegate(
                OnVideoLoaded,
                OnVideoShown,
                OnVideoClosed,
                OnVideoFinished,
                OnVideoFailed
            );
        }

        public void DestroyAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiDestroAd(adType);
        }

        #region Intestital Delegate

        [MonoPInvokeCallback(typeof(YabbiInterstitialCallbacks))]
        internal static void OnInterstitialLoaded()
        {
            _interstitialAdListener?.OnInterstitialLoaded();
        }

        [MonoPInvokeCallback(typeof(YabbiInterstitialCallbacks))]
        internal static void OnInterstitialShown()
        {
            _interstitialAdListener?.OnInterstitialShown();
        }

        [MonoPInvokeCallback(typeof(YabbiInterstitialCallbacks))]
        internal static void OnInterstitialClosed()
        {
            _interstitialAdListener?.OnInterstitialClosed();
        }

        [MonoPInvokeCallback(typeof(YabbiInterstitialFailedCallbacks))]
        internal static void OnInterstitialFailed(string message)
        {
            _interstitialAdListener?.OnInterstitialFailed(message);
        }

        #endregion

        #region Video Delegate

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoLoaded()
        {
            _videoAdListener?.OnVideoLoaded();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoShown()
        {
            _videoAdListener?.OnVideoShown();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoClosed()
        {
            _videoAdListener?.OnVideoClosed();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoFinished()
        {
            _videoAdListener?.OnVideoFinished();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoFailedCallbacks))]
        internal static void OnVideoFailed(string message)
        {
            _videoAdListener?.OnVideoFailed(message);
        }

        #endregion
    }
}
#endif