#import <Foundation/Foundation.h>
#import <YabbiAds/YabbiAds-Swift.h>

typedef void (*YabbiRewardedVideoCallbacks) ();
typedef void (*YabbiRewardedVideoFailCallbacks) (const char *);

@interface YabbiRewardedVideoDelegate : NSObject <YabbiRewardedVideoDelegate>

@property (assign, nonatomic) YabbiRewardedVideoCallbacks onRewardedVideoLoadedCallback;
@property (assign, nonatomic) YabbiRewardedVideoFailCallbacks oRewardedVideoLoadFailedCallback;
@property (assign, nonatomic) YabbiRewardedVideoCallbacks onRewardedVideoShownCallback;
@property (assign, nonatomic) YabbiRewardedVideoFailCallbacks onRewardedVideoShowFailedCallback;
@property (assign, nonatomic) YabbiRewardedVideoCallbacks onRewardedVideoClosedCallback;
@property (assign, nonatomic) YabbiRewardedVideoCallbacks onRewardedVideoFinishedCallback;

@end
