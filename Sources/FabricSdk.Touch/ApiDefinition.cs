using System;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace Bindings.FabricSdk
{
    // @interface Fabric : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface Fabric
	{
		// +(instancetype _Nonnull)with:(NSArray * _Nonnull)kitClasses;
		[Static]
		[Export("with:")]
		Fabric With(NSObject[] kitClasses);

		// +(instancetype _Nonnull)sharedSDK;
		[Static]
		[Export("sharedSDK")]
		Fabric SharedSDK();

		// @property (assign, nonatomic) BOOL debug;
		[Export("debug")]
		bool Debug { get; set; }
	}
}

