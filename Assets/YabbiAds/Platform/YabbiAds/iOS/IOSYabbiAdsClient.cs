#if UNITY_IPHONE
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
        private static IRewardedAdListener _rewardedAdListener;

        private static YabbiConfiguration _configuration;

        public void Initialize(YabbiConfiguration configuration)
        {
            _configuration = configuration;
            YabbiAdsObjCBridge.YabbiInitialize(_configuration.PublisherID);
            YabbiAdsObjCBridge.YabbiInitializeAd( _configuration.InterstitialID, YabbiAdsType.Interstitial);
            YabbiAdsObjCBridge.YabbiInitializeAd(_configuration.RewardedID, YabbiAdsType.Rewarded);
        }

        public bool IsInitialized()
        {
            return _configuration?.PublisherID != null;
        }

        public bool CanLoadAd(int adType)
        {
            return YabbiAdsObjCBridge.YabbiIsAdInitialized(GetIosAdType(adType));
        }

        public void ShowAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiShowAd(GetIosAdType(adType));
        }

        public bool IsAdLoaded(int adType)
        {
            return YabbiAdsObjCBridge.YabbiIsAdLoaded(GetIosAdType(adType));
        }

        public void LoadAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiLoadAd(GetIosAdType(adType));
        }

        private static int GetIosAdType(int adType)
        {
            return adType == 3 ? 2 : adType;
        }

        public void SetAlwaysRequestLocation(int adType, bool isEnabled)
        {
            YabbiAdsObjCBridge.YabbiSetAlwaysRequestLocation(GetIosAdType(adType), isEnabled);
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

        public void SetRewardedCallbacks(IRewardedAdListener adListener)
        {
            _rewardedAdListener = adListener;
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
            _rewardedAdListener?.OnRewardedLoaded();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoShown()
        {
            _rewardedAdListener?.OnRewardedShown();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoClosed()
        {
            _rewardedAdListener?.OnRewardedClosed();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoCallbacks))]
        internal static void OnVideoFinished()
        {
            _rewardedAdListener?.OnRewardedFinished();
        }

        [MonoPInvokeCallback(typeof(YabbiVideoFailedCallbacks))]
        internal static void OnVideoFailed(string message)
        {
            _rewardedAdListener?.OnRewardedFailed(message);
        }

        #endregion
    }
}
#endif