#if UNITY_IPHONE
using System.Runtime.InteropServices;


namespace YabbiAds.Platform.iOS
{
    internal delegate void YabbiInterstitialCallbacks();

    internal delegate void YabbiInterstitialFailCallbacks(string messgae);

    internal delegate void YabbiRewardedVideoCallbacks();

    internal delegate void YabbiRewardedVideoFailCallbacks(string message);

    internal static class YabbiAdsObjCBridge
    {
        #region Declare external C interface

        [DllImport("__Internal")]
        internal static extern void YabbiInitialize(string publisherID, string interstitialID, string rewardedID);
        
        [DllImport("__Internal")]
        internal static extern void YabbiLoadAd(int adType);
        
        [DllImport("__Internal")]
        internal static extern bool YabbiCanLoadAd(int adType);
        
        [DllImport("__Internal")]
        internal static extern void YabbiShowAd(int adType);

        [DllImport("__Internal")]
        internal static extern bool YabbiIsAdLoaded(int adType);

        [DllImport("__Internal")]
        internal static extern bool YabbiIsInitialized();

        [DllImport("__Internal")]
        internal static extern void YabbiDestroyAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiSetInterstitialDelegate(
            YabbiInterstitialCallbacks onLoaded,
            YabbiInterstitialFailCallbacks onLoadedFailed,
            YabbiInterstitialCallbacks onShown,
            YabbiInterstitialFailCallbacks onShownFailed,
            YabbiInterstitialCallbacks onClosed
        );

        [DllImport("__Internal")]
        internal static extern void YabbiSetRewardedDelegate(
            YabbiRewardedVideoCallbacks onLoaded,
            YabbiRewardedVideoFailCallbacks onLoadedFailed,
            YabbiRewardedVideoCallbacks onShown,
            YabbiRewardedVideoFailCallbacks onShownFailed,
            YabbiRewardedVideoCallbacks onClosed,
            YabbiRewardedVideoCallbacks onFinished
        );

        #endregion
    }
}
#endif