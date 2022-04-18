namespace YabbiAds.Common
{
    public interface IVideoAdListener
    {
        void OnVideoLoaded();
        void OnVideoFailed(string error);
        void OnVideoShown();
        void OnVideoFinished();
        void OnVideoClosed();
    }
}