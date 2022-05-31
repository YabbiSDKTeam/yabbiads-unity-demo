#if UNITY_IPHONE
using System.Runtime.InteropServices;


namespace YabbiAds.Platform.iOS
{

    internal delegate void YabbiInterstitialCallbacks();

    internal delegate void YabbiInterstitialFailedCallbacks(string messgae);

    internal delegate void YabbiVideoCallbacks();

    internal delegate void YabbiVideoFailedCallbacks(string message);


    internal static class YabbiAdsObjCBridge
    {
        #region Declare external C interface

        [DllImport("__Internal")]
        internal static extern void YabbiInitialize(string publisherID);

        [DllImport("__Internal")]
        internal static extern void YabbiInitializeAd(string unitID, int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiLoadAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiShowAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiSetAlwaysRequestLocation(int adType, bool isEnabled);

        [DllImport("__Internal")]
        internal static extern bool YabbiIsAdLoaded(int adType);

        [DllImport("__Internal")]
        internal static extern bool YabbiIsAdInitialized(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiDestroAd(int adType);

        [DllImport("__Internal")]
        internal static extern void YabbiSetInterstitialDelegate(
            YabbiInterstitialCallbacks onLoaded,
            YabbiInterstitialCallbacks onShown,
            YabbiInterstitialCallbacks onClosed,
           YabbiInterstitialFailedCallbacks onFailed
        );

        [DllImport("__Internal")]
        internal static extern void YabbiSetVideoDelegate(
            YabbiVideoCallbacks onLoaded,
            YabbiVideoCallbacks onShown,
            YabbiVideoCallbacks onClosed,
            YabbiVideoCallbacks onFinished,
            YabbiVideoFailedCallbacks onFailed
        );

        #endregion
    }
}
#endif