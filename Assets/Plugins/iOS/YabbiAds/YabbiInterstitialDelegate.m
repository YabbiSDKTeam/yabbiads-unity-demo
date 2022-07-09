#if defined(__has_include) && __has_include("UnityInterface.h")
#import "UnityInterface.h"
#endif
#import "YabbiInterstitialDelegate.h"



@implementation YabbiInterstitialDelegate

-(void) onInterstitialLoaded {
    if(self.onInterstitialLoadedCallback) {
        self.onInterstitialLoadedCallback();
    }
}

- (void)onInterstitialLoadFailed:(NSString *)error {
    if(self.onInterstitialLoadFailedCallback) {
        self.onInterstitialLoadFailedCallback([error UTF8String]);
    }
}

- (void)onInterstitialShown {
    if(self.onInterstitialShownCallback) {
        self.onInterstitialShownCallback();
    }
}

- (void)onInterstitialShowFailed:(NSString *)error {
    if(self.onInterstitialShowFailedCallback) {
        self.onInterstitialShowFailedCallback([error UTF8String]);
    }
}

- (void)onInterstitialClosed {
    if(self.onInterstitialClosedCallback) {
        self.onInterstitialClosedCallback();
    }
}

@end

