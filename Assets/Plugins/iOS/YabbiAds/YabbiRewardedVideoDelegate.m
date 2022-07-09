#if defined(__has_include) && __has_include("UnityInterface.h")
#import "UnityInterface.h"
#endif
#import "YabbiRewardedVideoDelegate.h"

@implementation YabbiRewardedVideoDelegate

- (void)oRewardedVideoLoadFailed:(NSString *)error {
    if(self.oRewardedVideoLoadFailedCallback) {
        self.oRewardedVideoLoadFailedCallback([error UTF8String]);
    }
}

- (void)onRewardedVideoShown {
    if(self.onRewardedVideoShownCallback) {
        self.onRewardedVideoShownCallback();
    }
}

- (void)onRewardedVideoShowFailed:(NSString *)error {
    if(self.onRewardedVideoShowFailedCallback) {
        self.onRewardedVideoShowFailedCallback([error UTF8String]);
    }
}

- (void)onRewardedVideolLoaded {
    if(self.onRewardedVideoLoadedCallback) {
        self.onRewardedVideoLoadedCallback();
    }
}

- (void)onRewardedVideoClosed {
    if(self.onRewardedVideoClosedCallback) {
        self.onRewardedVideoClosedCallback();
    }
}

- (void)onRewardedVideoFinished {
    if(self.onRewardedVideoFinishedCallback) {
        self.onRewardedVideoFinishedCallback();
    }
}

@end
