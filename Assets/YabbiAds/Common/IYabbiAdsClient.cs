using System.Collections.Generic;

namespace YabbiAds.Common
{
    public interface IYabbiAdsClient
    {
        public void Initialize(string publisherID);
        public void InitializeAd(string unitID, int adType);
        bool IsAdInitialized(int adType);
        void ShowAd(int adType);
        bool IsAdLoaded(int adType);
        void LoadAd(int adType);
        public void SetAlwaysRequestLocation(int adType, bool isEnabled);
        void SetInterstitialCallbacks(IInterstitialAdListener adListener);
        void SetVideoCallbacks(IVideoAdListener adListener);
        void DestroyAd(int adType);
    }
}