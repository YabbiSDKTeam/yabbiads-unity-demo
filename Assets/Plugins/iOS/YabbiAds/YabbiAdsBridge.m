#if defined(__has_include) && __has_include("UnityAppController.h")
#import "UnityAppController.h"
#endif
#import <Foundation/Foundation.h>
#import <YabbiAds/YabbiAds-Swift.h>
#import "YabbiInterstitialDelegate.h"
#import "YabbiRewardedVideoDelegate.h"

#if defined(__has_include) && __has_include("UnityAppController.h")
UIViewController *RootViewController(void) {
    return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;
}
#endif

void YabbiInitialize(const char *publisherID, const char *interstitialID, const char *rewardedID) {
    YabbiConfiguration *configuration = [[YabbiConfiguration alloc] initWithPublisherID:[NSString stringWithUTF8String:publisherID] interstitialID:[NSString stringWithUTF8String:interstitialID] rewardedID:[NSString stringWithUTF8String:rewardedID]];
    [YabbiAds initialize:configuration];
}

BOOL YabbiIsInitialized(void) {
    return [YabbiAds isInitialized];
}

void YabbiLoadAd(int adType){
    [YabbiAds loadAd:adType];
}

#if defined(__has_include) && __has_include("UnityAppController.h")
void YabbiShowAd(int adType) {
    return [YabbiAds showAd:adType rootViewController:RootViewController()];
}
#endif

BOOL YabbiCanLoadAd(int adType){
    return [YabbiAds canLoadAd:adType];
}

BOOL YabbiIsAdLoaded(int adType){
    return [YabbiAds isAdLoaded:adType];
}

void YabbiDestroyAd(int adType){
    return [YabbiAds destroyAd:adType];
}

static YabbiInterstitialDelegate *YabbiInterstitialDelegateInstance;
void YabbiSetInterstitialDelegate(
                                  YabbiInterstitialCallbacks onInterstitialLoaded,
                                  YabbiInterstitialFailCallbacks onInterstitialLoadFailed,
                                  YabbiInterstitialCallbacks onInterstitialShown,
                                  YabbiInterstitialFailCallbacks onRewardedVideoShownFailed,
                                  YabbiInterstitialCallbacks onInterstitialClosed
                                  ) {
    
    YabbiInterstitialDelegateInstance = [YabbiInterstitialDelegate new];
    
    YabbiInterstitialDelegateInstance.onInterstitialLoadedCallback = onInterstitialLoaded;
    YabbiInterstitialDelegateInstance.onInterstitialLoadFailedCallback = onInterstitialLoadFailed;
    YabbiInterstitialDelegateInstance.onInterstitialShownCallback = onInterstitialShown;
    YabbiInterstitialDelegateInstance.onInterstitialShowFailedCallback = onRewardedVideoShownFailed;
    YabbiInterstitialDelegateInstance.onInterstitialClosedCallback = onInterstitialClosed;
    
    
    [YabbiAds setInterstitialDelegate:YabbiInterstitialDelegateInstance];
}

static YabbiRewardedVideoDelegate *YabbiRewardedVideoDelegateInstance;
void YabbiSetRewardedDelegate(
                                   YabbiRewardedVideoCallbacks onRewardedVideoLoaded,
                                   YabbiRewardedVideoFailCallbacks oRewardedVideoLoadFailed,
                                   YabbiRewardedVideoCallbacks onRewardedVideoShown,
                                   YabbiRewardedVideoFailCallbacks onRewardedVideoShownFailed,
                                   YabbiRewardedVideoCallbacks onRewardedVideoClosed,
                                   YabbiRewardedVideoCallbacks onRewardedVideoFinished
                                   ) {
    
    YabbiRewardedVideoDelegateInstance = [YabbiRewardedVideoDelegate new];
    
    YabbiRewardedVideoDelegateInstance.onRewardedVideoLoadedCallback = onRewardedVideoLoaded;
    YabbiRewardedVideoDelegateInstance.oRewardedVideoLoadFailedCallback = oRewardedVideoLoadFailed;
    YabbiRewardedVideoDelegateInstance.onRewardedVideoShownCallback = onRewardedVideoShown;
    YabbiRewardedVideoDelegateInstance.onRewardedVideoShowFailedCallback = onRewardedVideoShownFailed;
    YabbiRewardedVideoDelegateInstance.onRewardedVideoClosedCallback = onRewardedVideoClosed;
    YabbiRewardedVideoDelegateInstance.onRewardedVideoFinishedCallback = onRewardedVideoFinished;
    
    [YabbiAds setRewardedDelegate:YabbiRewardedVideoDelegateInstance];
}
