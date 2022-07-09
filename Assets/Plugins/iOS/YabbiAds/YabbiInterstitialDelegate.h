#import <Foundation/Foundation.h>
#import <YabbiAds/YabbiAds-Swift.h>

typedef void (*YabbiInterstitialCallbacks) ();
typedef void (*YabbiInterstitialFailCallbacks) (const char *);

@interface YabbiInterstitialDelegate : NSObject <YabbiInterstitialDelegate>

@property (assign, nonatomic) YabbiInterstitialCallbacks onInterstitialLoadedCallback;
@property (assign, nonatomic) YabbiInterstitialFailCallbacks onInterstitialLoadFailedCallback;
@property (assign, nonatomic) YabbiInterstitialCallbacks onInterstitialShownCallback;
@property (assign, nonatomic) YabbiInterstitialFailCallbacks onInterstitialShowFailedCallback;
@property (assign, nonatomic) YabbiInterstitialCallbacks onInterstitialClosedCallback;

@end
