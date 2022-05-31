namespace YabbiAds.Common
{
    public interface IRewardedAdListener
    {
        void OnRewardedLoaded();
        void OnRewardedFailed(string error);
        void OnRewardedShown();
        void OnRewardedFinished();
        void OnRewardedClosed();
    }
}