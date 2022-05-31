namespace YabbiAds.Common
{
    public class YabbiConfiguration
    {
        
        public readonly string PublisherID;
        public readonly string InterstitialID;
        public readonly string RewardedID;

        public YabbiConfiguration(string publisherID,string interstitialID, string rewardedID) {
            PublisherID = publisherID;
            InterstitialID = interstitialID;
            RewardedID = rewardedID;
        }
    }
}