namespace YabbiAds.Common
{
    public interface IInterstitialAdListener
    {
        void OnInterstitialLoaded();
        void OnInterstitialFailed(string error);
        void OnInterstitialShown();
        void OnInterstitialClosed();
    }
}