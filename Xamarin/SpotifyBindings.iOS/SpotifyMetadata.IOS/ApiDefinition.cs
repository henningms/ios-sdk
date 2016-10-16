using System;

using Foundation;
using ObjCRuntime;
using CoreGraphics;
using UIKit;
using System.Collections.Generic;
using SpotifyMetadata.iOS;

namespace SpotifyMetadata.iOS
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

	//[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{

		// extern double SpotifyMetadataVersionNumber;
		[Static]
		[Field("SpotifyMetadataVersionNumber", "__Internal")]
		double SpotifyMetadataVersionNumber { get; }

		// extern const unsigned char [] SpotifyMetadataVersionString;
		[Static]
		[Field("SpotifyMetadataVersionString", "__Internal")]
		byte[] SpotifyMetadataVersionString { get; }
	}

	// @protocol SPTJSONObject <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SPTJSONObject
	{
		// @required -(id)initWithDecodedJSONObject:(id)decodedObject error:(NSError **)error;
		[Abstract]
		[Export("initWithDecodedJSONObject:error:")]
		IntPtr Error(NSObject decodedObject, out NSError error);

		// @required @property (readonly, copy, nonatomic) id decodedJSONObject;
		[Abstract]
		[Export("decodedJSONObject", ArgumentSemantic.Copy)]
		NSObject DecodedJSONObject { get; }
	}

	// @interface SPTJSONDecoding : NSObject
	[BaseType(typeof(NSObject))]
	interface SPTJSONDecoding
	{
		// +(id)SPObjectFromDecodedJSON:(id)decodedJson error:(NSError **)error;
		[Static]
		[Export("SPObjectFromDecodedJSON:error:")]
		NSObject SPObjectFromDecodedJSON(NSObject decodedJson, out NSError error);

		// +(id)SPObjectFromEncodedJSON:(NSData *)json error:(NSError **)error;
		[Static]
		[Export("SPObjectFromEncodedJSON:error:")]
		NSObject SPObjectFromEncodedJSON(NSData json, out NSError error);

		// +(id)partialSPObjectFromDecodedJSON:(id)decodedJson error:(NSError **)error;
		[Static]
		[Export("partialSPObjectFromDecodedJSON:error:")]
		NSObject PartialSPObjectFromDecodedJSON(NSObject decodedJson, out NSError error);

		// +(id)partialSPObjectFromEncodedJSON:(NSData *)json error:(NSError **)error;
		[Static]
		[Export("partialSPObjectFromEncodedJSON:error:")]
		NSObject PartialSPObjectFromEncodedJSON(NSData json, out NSError error);
	}

	// @interface SPTListPage : NSObject<SPTTrackProvider>
	[BaseType(typeof(NSObject))]
	interface SPTListPage : SPTTrackProvider
	{
		[Export("range")]
		NSRange Range { get; }

		[Export("totalListLength")]
		nuint TotalListLength { get; }

		[Export("hasNextPage")]
		bool HasNextPage { get; }

		[Export("hasPreviousPage")]
		bool HasPreviousPage { get; }

		[Export("nextPageUrl")]
		NSUrl NextPageUrl { get; }

		[Export("previousPageUrl")]
		NSUrl PreviousPageUrl { get; }

		[Export("isComplete")]
		bool IsComplete { get; }

		[Export("items")]
		NSObject[] Items { get; }
	}

	// @interface SPTJSONObjectBase : NSObject <SPTJSONObject>
	[BaseType(typeof(NSObject))]
	interface SPTJSONObjectBase : SPTJSONObject
	{
		// @property (readwrite, copy, nonatomic) id decodedJSONObject;
		[Export("decodedJSONObject", ArgumentSemantic.Copy)]
		NSObject DecodedJSONObject { get; set; }
	}

	// typedef void (^SPTRequestCallback)(NSError *, id);
	delegate void SPTRequestCallback(NSError arg0, NSObject arg1);

	// typedef void (^SPTRequestDataCallback)(NSError *, NSURLResponse *, NSData *);
	delegate void SPTRequestDataCallback(NSError arg0, NSUrlResponse arg1, NSData arg2);

	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		[Static]
		// extern NSString *const SPTMarketFromToken;
		[Field("SPTMarketFromToken", "__Internal")]
		NSString SPTMarketFromToken { get; }
	}

	// @protocol SPTRequestHandlerProtocol
	[BaseType(typeof(NSObject))]
	[Protocol, Model]
	interface SPTRequestHandlerProtocol
	{
		// @required -(void)performRequest:(NSURLRequest *)request callback:(SPTRequestDataCallback)block;
		[Abstract]
		[Export("performRequest:callback:")]
		void Callback(NSUrlRequest request, SPTRequestDataCallback block);
	}

	// @interface SPTRequest : NSObject
	[BaseType(typeof(NSObject))]
	interface SPTRequest
	{
		// +(id<SPTRequestHandlerProtocol>)sharedHandler;
		// +(void)setSharedHandler:(id<SPTRequestHandlerProtocol>)handler;
		[Static]
		[Export("sharedHandler")]
		//[Verify(MethodToProperty)]
		SPTRequestHandlerProtocol SharedHandler { get; set; }

		// +(NSURLRequest *)createRequestForURL:(NSURL *)url withAccessToken:(NSString *)accessToken httpMethod:(NSString *)httpMethod values:(id)values valueBodyIsJSON:(BOOL)encodeAsJSON sendDataAsQueryString:(BOOL)dataAsQueryString error:(NSError **)error;
		[Static]
		[Export("createRequestForURL:withAccessToken:httpMethod:values:valueBodyIsJSON:sendDataAsQueryString:error:")]
		NSUrlRequest CreateRequestForURL(NSUrl url, string accessToken, string httpMethod, NSObject values, bool encodeAsJSON, bool dataAsQueryString, out NSError error);
	}

	// @protocol SPTTrackProvider <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface SPTTrackProvider
	{
		// @required -(NSArray *)tracksForPlayback;
		[Abstract]
		[Export("tracksForPlayback")]
		//[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
		NSObject[] TracksForPlayback { get; }

		// @required -(NSURL *)playableUri;
		[Abstract]
		[Export("playableUri")]
		//[Verify(MethodToProperty)]
		NSUrl PlayableUri { get; }
	}

	// @interface SPTAlbum : SPTPartialAlbum <SPTJSONObject, SPTTrackProvider>
	[BaseType(typeof(SPTPartialAlbum))]
	interface SPTAlbum : SPTJSONObject, SPTTrackProvider
	{
		// @property (readonly, copy, nonatomic) NSDictionary * externalIds;
		[Export("externalIds", ArgumentSemantic.Copy)]
		NSDictionary ExternalIds { get; }

		// @property (readonly, nonatomic) NSArray * artists;
		[Export("artists")]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] Artists { get; }

		// @property (readonly, nonatomic) SPTListPage * firstTrackPage;
		[Export("firstTrackPage")]
		SPTListPage FirstTrackPage { get; }

		// @property (readonly, nonatomic) NSInteger releaseYear;
		[Export("releaseYear")]
		nint ReleaseYear { get; }

		// @property (readonly, nonatomic) NSDate * releaseDate;
		[Export("releaseDate")]
		NSDate ReleaseDate { get; }

		// @property (readonly, copy, nonatomic) NSArray * genres;
		[Export("genres", ArgumentSemantic.Copy)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] Genres { get; }

		// @property (readonly, nonatomic) double popularity;
		[Export("popularity")]
		double Popularity { get; }

		// +(NSURLRequest *)createRequestForAlbum:(NSURL *)uri withAccessToken:(NSString *)accessToken market:(NSString *)market error:(NSError **)error;
		[Static]
		[Export("createRequestForAlbum:withAccessToken:market:error:")]
		NSUrlRequest CreateRequestForAlbum(NSUrl uri, string accessToken, string market, out NSError error);

		// +(NSURLRequest *)createRequestForAlbums:(NSArray *)uris withAccessToken:(NSString *)accessToken market:(NSString *)market error:(NSError **)error;
		[Static]
		[Export("createRequestForAlbums:withAccessToken:market:error:")]
		//[Verify(StronglyTypedNSArray)]
		NSUrlRequest CreateRequestForAlbums(NSObject[] uris, string accessToken, string market, out NSError error);

		// +(instancetype)albumFromData:(NSData *)data withResponse:(NSURLResponse *)response error:(NSError **)error;
		[Static]
		[Export("albumFromData:withResponse:error:")]
		SPTAlbum AlbumFromData(NSData data, NSUrlResponse response, out NSError error);

		// +(instancetype)albumFromDecodedJSON:(id)decodedObject error:(NSError **)error;
		[Static]
		[Export("albumFromDecodedJSON:error:")]
		SPTAlbum AlbumFromDecodedJSON(NSObject decodedObject, out NSError error);

		// +(NSArray *)albumsFromDecodedJSON:(id)decodedObject error:(NSError **)error;
		[Static]
		[Export("albumsFromDecodedJSON:error:")]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] AlbumsFromDecodedJSON(NSObject decodedObject, out NSError error);

		// +(void)albumWithURI:(NSURL *)uri accessToken:(NSString *)accessToken market:(NSString *)market callback:(SPTRequestCallback)block;
		[Static]
		[Export("albumWithURI:accessToken:market:callback:")]
		void AlbumWithURI(NSUrl uri, string accessToken, string market, SPTRequestCallback block);

		// +(void)albumsWithURIs:(NSArray *)uris accessToken:(NSString *)accessToken market:(NSString *)market callback:(SPTRequestCallback)block;
		[Static]
		[Export("albumsWithURIs:accessToken:market:callback:")]
		//[Verify(StronglyTypedNSArray)]
		void AlbumsWithURIs(NSObject[] uris, string accessToken, string market, SPTRequestCallback block);

		// +(BOOL)isAlbumURI:(NSURL *)uri;
		[Static]
		[Export("isAlbumURI:")]
		bool IsAlbumURI(NSUrl uri);
	}

	// @interface SPTPartialObject : NSObject
	[BaseType(typeof(NSObject))]
	interface SPTPartialObject
	{
		[Export("name")]
		string Name { get; }

		[Export("uri")]
		string Uri { get; }
	}

	// @interface SPTPartialPlaylist : SPTJSONObjectBase <SPTPartialObject, SPTTrackProvider>
	[BaseType(typeof(SPTJSONObjectBase))]
	interface SPTPartialPlaylist : SPTPartialObject, SPTTrackProvider
	{
		// @property (readonly, copy, nonatomic) NSString * name;
		[Export("name")]
		new string Name { get; }

		// @property (readonly, copy, nonatomic) NSURL * uri;
		[Export("uri", ArgumentSemantic.Copy)]
		new NSUrl Uri { get; }

		// @property (readonly, copy, nonatomic) NSURL * playableUri;
		[Export("playableUri", ArgumentSemantic.Copy)]
		new NSUrl PlayableUri { get; }

		// @property (readonly, nonatomic) SPTUser * owner;
		[Export("owner")]
		SPTUser Owner { get; }

		// @property (readonly, nonatomic) BOOL isCollaborative;
		[Export("isCollaborative")]
		bool IsCollaborative { get; }

		// @property (readonly, nonatomic) BOOL isPublic;
		[Export("isPublic")]
		bool IsPublic { get; }

		// @property (readonly, nonatomic) NSUInteger trackCount;
		[Export("trackCount")]
		nuint TrackCount { get; }

		// @property (readonly, copy, nonatomic) NSArray * images;
		[Export("images", ArgumentSemantic.Copy)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] Images { get; }

		// @property (readonly, nonatomic) SPTImage * smallestImage;
		[Export("smallestImage")]
		SPTImage SmallestImage { get; }

		// @property (readonly, nonatomic) SPTImage * largestImage;
		[Export("largestImage")]
		SPTImage LargestImage { get; }

		// +(instancetype)partialPlaylistFromDecodedJSON:(id)decodedObject error:(NSError **)error;
		[Static]
		[Export("partialPlaylistFromDecodedJSON:error:")]
		SPTPartialPlaylist PartialPlaylistFromDecodedJSON(NSObject decodedObject, out NSError error);
	}

	// @interface SPTPartialTrack : SPTJSONObjectBase <SPTPartialObject, SPTTrackProvider>
	[BaseType(typeof(SPTJSONObjectBase))]
	interface SPTPartialTrack : SPTPartialObject, SPTTrackProvider
	{
		// @property (readonly, copy, nonatomic) NSString * identifier;
		[Export("identifier")]
		string Identifier { get; }

		// @property (readonly, copy, nonatomic) NSString * name;
		[Export("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSURL * playableUri;
		[Export("playableUri", ArgumentSemantic.Copy)]
		NSUrl PlayableUri { get; }

		// @property (readonly, copy, nonatomic) NSURL * sharingURL;
		[Export("sharingURL", ArgumentSemantic.Copy)]
		NSUrl SharingURL { get; }

		// @property (readonly, nonatomic) NSTimeInterval duration;
		[Export("duration")]
		double Duration { get; }

		// @property (readonly, copy, nonatomic) NSArray * artists;
		[Export("artists", ArgumentSemantic.Copy)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] Artists { get; }

		// @property (readonly, nonatomic) NSInteger discNumber;
		[Export("discNumber")]
		nint DiscNumber { get; }

		// @property (readonly, nonatomic) BOOL flaggedExplicit;
		[Export("flaggedExplicit")]
		bool FlaggedExplicit { get; }

		// @property (readonly, nonatomic) BOOL isPlayable;
		[Export("isPlayable")]
		bool IsPlayable { get; }

		// @property (readonly, nonatomic) BOOL hasPlayable;
		[Export("hasPlayable")]
		bool HasPlayable { get; }

		// @property (readonly, copy, nonatomic) NSArray * availableTerritories;
		[Export("availableTerritories", ArgumentSemantic.Copy)]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] AvailableTerritories { get; }

		// @property (readonly, copy, nonatomic) NSURL * previewURL;
		[Export("previewURL", ArgumentSemantic.Copy)]
		NSUrl PreviewURL { get; }

		// @property (readonly, nonatomic) NSInteger trackNumber;
		[Export("trackNumber")]
		nint TrackNumber { get; }

		// @property (readonly, nonatomic, strong) SPTPartialAlbum * album;
		[Export("album", ArgumentSemantic.Strong)]
		SPTPartialAlbum Album { get; }

		// +(instancetype)partialTrackFromDecodedJSON:(id)decodedObject error:(NSError **)error;
		[Static]
		[Export("partialTrackFromDecodedJSON:error:")]
		SPTPartialTrack PartialTrackFromDecodedJSON(NSObject decodedObject, out NSError error);
	}

	// typedef void (^SPTMetadataErrorableOperationCallback)(NSError *);
	delegate void SPTMetadataErrorableOperationCallback(NSError arg0);

	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const SPTPlaylistSnapshotPublicKey;
		[Static]
		[Field("SPTPlaylistSnapshotPublicKey", "__Internal")]
		NSString SPTPlaylistSnapshotPublicKey { get; }

		// extern NSString *const SPTPlaylistSnapshotNameKey;
		[Static]
		[Field("SPTPlaylistSnapshotNameKey", "__Internal")]
		NSString SPTPlaylistSnapshotNameKey { get; }
	}

	// typedef void (^SPTPlaylistCreationCallback)(NSError *, SPTPlaylistSnapshot *);
	delegate void SPTPlaylistCreationCallback(NSError arg0, SPTPlaylistSnapshot arg1);

	// @interface SPTPlaylistSnapshot : SPTPartialPlaylist <SPTJsonObject>
	[BaseType(typeof(SPTPartialPlaylist))]
	interface SPTPlaylistSnapshot : SPTJSONObject
	{
	}
	// @interface SPTTrack : SPTPartialTrack <SPTJSONObject>
	[BaseType(typeof(SPTPartialTrack))]
	interface SPTTrack : SPTJSONObject
	{
		// @property (readonly, nonatomic) double popularity;
		[Export("popularity")]
		double Popularity { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * externalIds;
		[Export("externalIds", ArgumentSemantic.Copy)]
		NSDictionary ExternalIds { get; }

		// +(NSURLRequest *)createRequestForTrack:(NSURL *)uri withAccessToken:(NSString *)accessToken market:(NSString *)market error:(NSError **)error;
		[Static]
		[Export("createRequestForTrack:withAccessToken:market:error:")]
		NSUrlRequest CreateRequestForTrack(NSUrl uri, string accessToken, string market, out NSError error);

		// +(NSURLRequest *)createRequestForTracks:(NSArray *)uris withAccessToken:(NSString *)accessToken market:(NSString *)market error:(NSError **)error;
		[Static]
		[Export("createRequestForTracks:withAccessToken:market:error:")]
		//[Verify(StronglyTypedNSArray)]
		NSUrlRequest CreateRequestForTracks(NSObject[] uris, string accessToken, string market, out NSError error);

		// +(instancetype)trackFromData:(NSData *)data withResponse:(NSURLResponse *)response error:(NSError **)error;
		[Static]
		[Export("trackFromData:withResponse:error:")]
		SPTTrack TrackFromData(NSData data, NSUrlResponse response, out NSError error);

		// +(instancetype)trackFromDecodedJSON:(id)decodedObject error:(NSError **)error;
		[Static]
		[Export("trackFromDecodedJSON:error:")]
		SPTTrack TrackFromDecodedJSON(NSObject decodedObject, out NSError error);

		// +(NSArray *)tracksFromData:(NSData *)data withResponse:(NSURLResponse *)response error:(NSError **)error;
		[Static]
		[Export("tracksFromData:withResponse:error:")]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] TracksFromData(NSData data, NSUrlResponse response, out NSError error);

		// +(NSArray *)tracksFromDecodedJSON:(id)decodedObject error:(NSError **)error;
		[Static]
		[Export("tracksFromDecodedJSON:error:")]
		//[Verify(StronglyTypedNSArray)]
		NSObject[] TracksFromDecodedJSON(NSObject decodedObject, out NSError error);

		// +(void)trackWithURI:(NSURL *)uri accessToken:(NSString *)accessToken market:(NSString *)market callback:(SPTRequestCallback)block;
		[Static]
		[Export("trackWithURI:accessToken:market:callback:")]
		void TrackWithURI(NSUrl uri, string accessToken, string market, SPTRequestCallback block);

		// +(void)tracksWithURIs:(NSArray *)uris accessToken:(NSString *)accessToken market:(NSString *)market callback:(SPTRequestCallback)block;
		[Static]
		[Export("tracksWithURIs:accessToken:market:callback:")]
		//[Verify(StronglyTypedNSArray)]
		void TracksWithURIs(NSObject[] uris, string accessToken, string market, SPTRequestCallback block);

		// +(BOOL)isTrackURI:(NSURL *)uri;
		[Static]
		[Export("isTrackURI:")]
		bool IsTrackURI(NSUrl uri);

		// +(NSString *)identifierFromURI:(NSURL *)uri;
		[Static]
		[Export("identifierFromURI:")]
		string IdentifierFromURI(NSUrl uri);

		// +(NSArray *)identifiersFromArray:(NSArray *)tracks;
		[Static]
		[Export("identifiersFromArray:")]
		//[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
		NSObject[] IdentifiersFromArray(NSObject[] tracks);

		// +(NSArray *)urisFromArray:(NSArray *)tracks;
		[Static]
		[Export("urisFromArray:")]
		//[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
		NSObject[] UrisFromArray(NSObject[] tracks);

		// +(NSArray *)uriStringsFromArray:(NSArray *)tracks;
		[Static]
		[Export("uriStringsFromArray:")]
		//[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
		NSObject[] UriStringsFromArray(NSObject[] tracks);
	}

	// @interface SPTUser : SPTJSONObjectBase
	[BaseType(typeof(SPTJSONObjectBase))]
	interface SPTUser : SPTJSONObjectBase
	{
		[Export("displayName")]
		string DisplayName { get; }

		[Export("canonicalUserName")]
		string CanonicalUsername { get; }

		[Export("territory")]
		string Territory { get; }

		[Export("emailAddress")]
		string Email { get; }

		[Export("uri")]
		NSUrl Uri { get; }

		[Export("sharingURL")]
		NSUrl SharingUrl { get; }

		[Export("images")]
		SPTImage[] Images { get; }

		[Export("smallestImage")]
		SPTImage SmallestImage { get; }

		[Export("largestImage")]
		SPTImage LargestImage { get; }

		[Export("product")]
		SPTProduct Product { get; }

		[Static]
		[Export("createRequestForCurrentUserWithAccessToken:accessToken:error")]
		NSUrlRequest CreateRequestForCurrentUserWithAccessToken(string accessToken, out NSError error);

		[Static]
		[Export("requestCurrentUserWithAccessToken:accessToken:block")]
		void RequestCurrentUserWithAccessToken(string accessToken, SPTRequestCallback block);

		[Static]
		[Export("requestUser:username:accessToken:block")]
		void RequestUser(string username, string accessToken, SPTRequestCallback block);

		[Static]
		[Export("userFromData:data:response:error")]
		SPTUser UserFromData(NSData data, NSUrlResponse response, out NSError error);

		[Static]
		[Export("userFromDecodedJSON:decodedObject:error")]
		SPTUser UserFromDecodedJson(NSObject decodedObject, out NSError error);
	}

	// @interface SPTImage : NSObject
	[BaseType(typeof(NSObject))]
	interface SPTImage
	{
		[Export("size")]
		CGSize Size { get; }

		[Export("imageURL")]
		NSUrl ImageUrl { get; }

		[Static]
		[Export("imageFromDecodedJSON:decodedObject:error")]
		SPTImage ImageFromDecodedJSON(NSObject decodedObject, out NSError error);
	}

	// @interface SPTPartialAlbum : SPTJSONObjectBase<SPTPartialObject>
	[BaseType(typeof(SPTJSONObjectBase))]
	interface SPTPartialAlbum : SPTPartialObject
	{
		[Export("identifier")]
		string Identifier { get; }

		[Export("name")]
		string Name { get; }

		[Export("uri")]
		NSUrl Uri { get; }

		[Export("playableUri")]
		NSUrl PlayableUri { get; }

		[Export("sharingUrl")]
		NSUrl SharingUrl { get; }

		[Export("covers")]
		SPTImage[] Covers { get; }

		[Export("smallestCover")]
		SPTImage SmallestCover { get; }

		[Export("largestCover")]
		SPTImage LargestCover { get; }

		[Export("availableTerritories")]
		string[] AvailableTerritories { get; }

		[Static]
		[Export("partialAlbumFromDecodedJSON:decodedObject:error")]
		SPTPartialAlbum FromDecodedJSON(NSObject decodedObject, out NSError error);
	}
}