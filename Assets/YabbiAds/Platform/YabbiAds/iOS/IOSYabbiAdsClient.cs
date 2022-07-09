#if UNITY_IPHONE && !UNITY_EDITOR
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
            YabbiAdsObjCBridge.YabbiInitialize(_configuration.PublisherID,  _configuration.InterstitialID, _configuration.RewardedID);
        }

        public bool IsInitialized()
        {
            return YabbiAdsObjCBridge.YabbiIsInitialized();
        }

        public bool CanLoadAd(int adType)
        {
            return YabbiAdsObjCBridge.YabbiCanLoadAd(adType);
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
        
        public void SetInterstitialCallbacks(IInterstitialAdListener adListener)
        {
            _interstitialAdListener = adListener;
            YabbiAdsObjCBridge.YabbiSetInterstitialDelegate(
                OnInterstitialLoaded,
                OnInterstitialFailed,
                OnInterstitialShown,
                OnInterstitialFailed,
                OnInterstitialClosed
            );
        }

        public void SetRewardedCallbacks(IRewardedAdListener adListener)
        {
            _rewardedAdListener = adListener;
            YabbiAdsObjCBridge.YabbiSetRewardedDelegate(
                OnRewardedVideoLoaded,
                OnRewardedVideoFailed,
                OnRewardedVideoShown,
                OnRewardedVideoFailed,
                OnRewardedVideoClosed,
                OnRewardedVideoFinished
            );
        }

        public void DestroyAd(int adType)
        {
            YabbiAdsObjCBridge.YabbiDestroyAd(adType);
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

        [MonoPInvokeCallback(typeof(YabbiInterstitialFailCallbacks))]
        internal static void OnInterstitialFailed(string message)
        {
            _interstitialAdListener?.OnInterstitialFailed(message);
        }

        #endregion

        #region Video Delegate

        [MonoPInvokeCallback(typeof(YabbiRewardedVideoCallbacks))]
        internal static void OnRewardedVideoLoaded()
        {
            _rewardedAdListener?.OnRewardedLoaded();
        }

        [MonoPInvokeCallback(typeof(YabbiRewardedVideoCallbacks))]
        internal static void OnRewardedVideoShown()
        {
            _rewardedAdListener?.OnRewardedShown();
        }

        [MonoPInvokeCallback(typeof(YabbiRewardedVideoCallbacks))]
        internal static void OnRewardedVideoClosed()
        {
            _rewardedAdListener?.OnRewardedClosed();
        }

        [MonoPInvokeCallback(typeof(YabbiRewardedVideoCallbacks))]
        internal static void OnRewardedVideoFinished()
        {
            _rewardedAdListener?.OnRewardedFinished();
        }

        [MonoPInvokeCallback(typeof(YabbiRewardedVideoFailCallbacks))]
        internal static void OnRewardedVideoFailed(string message)
        {
            _rewardedAdListener?.OnRewardedFailed(message);
        }

        #endregion
    }
}
#endif