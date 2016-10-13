//
//  DGTInviteFlowConfiguration.h
//  DigitsKit
//
//  Created by Yong Mao on 9/12/16.
//  Copyright © 2016 Twitter Inc. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface DGTInviteFlowConfiguration : NSObject

// required field to be used when the invites feature needs to display the app's name in the UI
@property (nonatomic, copy, readonly) NSString * appDisplayName;

// required field to be used as the prefilled text message for the sms composer UI
@property (nonatomic, copy, readonly) NSString * smsTextPrefillBody;

// override it to specify the title of the invite view
@property (nonatomic, copy, readwrite) NSString * inviteViewTitle;

// override it to specify the text to be used for invite button
@property (nonatomic, copy, readwrite) NSString * inviteButtonTitle;

- (instancetype)initWithAppName:(NSString *) appDisplayName inviteText:(NSString *)inviteText;

- (instancetype)init __attribute__((unavailable("Use -initWithAppName:inviteText: instead")));
@end
