using System;
using System.Collections.Generic;

namespace YabbiAds.Common
{
    public interface IYabbiAdsClient
    {
        public void Initialize(YabbiConfiguration configuration);
        public bool IsInitialized();
        bool CanLoadAd(int adType);
        void LoadAd(int adType);
        void ShowAd(int adType);
        bool IsAdLoaded(int adType);
        void SetInterstitialCallbacks(IInterstitialAdListener adListener);
        void SetRewardedCallbacks(IRewardedAdListener adListener);
        void DestroyAd(int adType);
    }
}