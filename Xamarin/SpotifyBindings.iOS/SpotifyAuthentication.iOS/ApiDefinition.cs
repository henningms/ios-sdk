using System;
using System.ComponentModel;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace SpotifyAuthentication.iOS
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     CGPoint Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
	//
	partial interface Constants
	{
		// extern double SpotifyAuthenticationVersionNumber;
		[Static]
		[Field("SpotifyAuthenticationVersionNumber", "__Internal")]
		double SpotifyAuthenticationVersionNumber { get; }

		// extern const unsigned char [] SpotifyAuthenticationVersionString;
		[Static]
		[Field("SpotifyAuthenticationVersionString", "__Internal")]
		byte[] SpotifyAuthenticationVersionString { get; }

		// extern NSString *const SPTAuthStreamingScope;
		[Static]
		[Field("SPTAuthStreamingScope", "__Internal")]
		NSString SPTAuthStreamingScope { get; }

		// extern NSString *const SPTAuthPlaylistReadPrivateScope;
		[Field("SPTAuthPlaylistReadPrivateScope", "__Internal")]
		[Static]
		NSString SPTAuthPlaylistReadPrivateScope { get; }

		// extern NSString *const SPTAuthPlaylistReadCollaborativeScope;
		[Field("SPTAuthPlaylistReadCollaborativeScope", "__Internal")]
		[Static]
		NSString SPTAuthPlaylistReadCollaborativeScope { get; }

		// extern NSString *const SPTAuthPlaylistModifyPublicScope;
		[Field("SPTAuthPlaylistModifyPublicScope", "__Internal")]
		[Static]
		NSString SPTAuthPlaylistModifyPublicScope { get; }

		// extern NSString *const SPTAuthPlaylistModifyPrivateScope;
		[Field("SPTAuthPlaylistModifyPrivateScope", "__Internal")]
		[Static]
		NSString SPTAuthPlaylistModifyPrivateScope { get; }

		// extern NSString *const SPTAuthUserFollowModifyScope;
		[Field("SPTAuthUserFollowModifyScope", "__Internal")]
		[Static]
		NSString SPTAuthUserFollowModifyScope { get; }

		// extern NSString *const SPTAuthUserFollowReadScope;
		[Field("SPTAuthUserFollowReadScope", "__Internal")]
		[Static]
		NSString SPTAuthUserFollowReadScope { get; }

		// extern NSString *const SPTAuthUserLibraryReadScope;
		[Field("SPTAuthUserLibraryReadScope", "__Internal")]
		[Static]
		NSString SPTAuthUserLibraryReadScope { get; }

		// extern NSString *const SPTAuthUserLibraryModifyScope;
		[Field("SPTAuthUserLibraryModifyScope", "__Internal")]
		[Static]
		NSString SPTAuthUserLibraryModifyScope { get; }

		// extern NSString *const SPTAuthUserReadPrivateScope;
		[Field("SPTAuthUserReadPrivateScope", "__Internal")]
		[Static]
		NSString SPTAuthUserReadPrivateScope { get; }

		// extern NSString *const SPTAuthUserReadTopScope;
		[Static]
		[Field("SPTAuthUserReadTopScope", "__Internal")]
		NSString SPTAuthUserReadTopScope { get; }

		// extern NSString *const SPTAuthUserReadBirthDateScope;
		[Static]
		[Field("SPTAuthUserReadBirthDateScope", "__Internal")]
		NSString SPTAuthUserReadBirthDateScope { get; }

		// extern NSString *const SPTAuthUserReadEmailScope;
		[Static]
		[Field("SPTAuthUserReadEmailScope", "__Internal")]
		NSString SPTAuthUserReadEmailScope { get; }

		// extern NSString *const SPTAuthSessionUserDefaultsKey;
		[Static]
		[Field("SPTAuthSessionUserDefaultsKey", "__Internal")]
		NSString SPTAuthSessionUserDefaultsKey { get; }
	}

	// typedef void (^SPTAuthCallback)(NSError *, SPTSession *);
	delegate void SPTAuthCallback(NSError arg0, SPTSession arg1);

    // @interface SPTAuth : NSObject
    [BaseType(typeof(NSObject))]
    interface SPTAuth
    {
        [Static]
        [Export("defaultInstance")]
        SPTAuth DefaultInstance { get; }

        [Export("clientID", ArgumentSemantic.Strong)]
        string ClientID { get; set; }

        [Export("redirectURL", ArgumentSemantic.Strong)]
        string RedirectURL { get; set; }

        [Export("requestedScopes", ArgumentSemantic.Strong)]
        string[] RequestedScopes { get; set; }

        [Export("allowNativeLogin"), DefaultValue("true")]
        bool AllowNativeLogin { get; set; }

        [Export("session", ArgumentSemantic.Strong)]
        SPTSession Session { get; set; }

        [Export("sessionUserDefaultsKey", ArgumentSemantic.Strong)]
        string SessionUserDefaultsKey { get; set; }

        [Export("tokenSwapURL", ArgumentSemantic.Strong)]
        NSUrl TokenSwapURL { get; set; }

        [Export("tokenRefreshURL", ArgumentSemantic.Strong)]
        NSUrl TokenRefreshUrl { get; set; }

        [Export("hasTokenSwapService")]
        bool HasTokenSwapService { get; }

        [Export("hasTokenRefreshService")]
        bool HasTokenRefreshService { get; }

        [Export("loginURL")]
        NSUrl LoginURL { get; }

        [Static]
        [Export("loginURLForClientId:clientId:withRedirectURL:scopes:responseType:allowNativeLogin")]
        NSUrl LoginURLForClientId(string clientId, NSUrl redirectUrl, string[] scopes, string responseType,
            bool allowNativeLogin);

        [Export("canHandleURL:")]
        bool CanHandleUrl(NSUrl callbackUrl);

        [Export("handleAuthCallbackWithTriggeredAuthURL:url:callback")]
        void HandleAuthCallbackWithTriggeredAuthUrl(NSUrl url, SPTAuthCallback block);

        [Static]
        [Export("supportsApplicationAuthentication")]
        bool SupportsApplicationAuthentication();

        [Static]
        [Export("spotifyApplicationIsInstalled")]
        bool SpotifyApplicationIsInstalled();

        [Export("renewSession:session:callback")]
        void RenewSession(SPTSession session, SPTAuthCallback callback);
    }

    [BaseType(typeof(NSSecureCoding))]
    interface SPTSession
    {
        [Export("canonicalUsername", ArgumentSemantic.Copy)]
        string CanonicalUsername { get; }

        [Export("accessToken", ArgumentSemantic.Copy)]
        string AccessToken { get; }

        [Export("encryptedRefreshToken", ArgumentSemantic.Copy)]
        string EncryptedRefreshToken { get; }

        [Export("ExpirationDate", ArgumentSemantic.Copy)]
        NSDate ExpirationDate { get; }

        [Export("tokenType", ArgumentSemantic.Copy)]
        string TokenType { get; set; }

        [Export("initWithUserName:userName:accessToken:expirationDate")]
        IntPtr Constructor(string username, string accessToken, NSDate expirationDate);

        [Export("initWithUserName:userName:accessToken:encryptedRefreshToken:expirationDate")]
        IntPtr Constructor(string username, string accessToken, string encryptedRefreshToken, NSDate expirationDate);

        [Export("initWithUserName:userName:accessToken:expirationTimeInterval")]
        IntPtr Constructor(string username, string accessToken, double timeInterval);

        [Export("isValid")]
        bool IsValid();
    }
}
