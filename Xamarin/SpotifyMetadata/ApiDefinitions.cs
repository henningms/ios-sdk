using Foundation;
using SpotifyMetadata;

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double SpotifyMetadataVersionNumber;
	[Field ("SpotifyMetadataVersionNumber", "__Internal")]
	double SpotifyMetadataVersionNumber { get; }

	// extern const unsigned char [] SpotifyMetadataVersionString;
	[Field ("SpotifyMetadataVersionString", "__Internal")]
	byte[] SpotifyMetadataVersionString { get; }
}

// typedef void (^SPTRequestCallback)(NSError *, id);
delegate void SPTRequestCallback (NSError arg0, NSObject arg1);

// typedef void (^SPTRequestDataCallback)(NSError *, NSURLResponse *, NSData *);
delegate void SPTRequestDataCallback (NSError arg0, NSUrlResponse arg1, NSData arg2);

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const SPTMarketFromToken;
	[Field ("SPTMarketFromToken", "__Internal")]
	NSString SPTMarketFromToken { get; }
}

// typedef void (^SPTMetadataErrorableOperationCallback)(NSError *);
delegate void SPTMetadataErrorableOperationCallback (NSError arg0);

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const SPTPlaylistSnapshotPublicKey;
	[Field ("SPTPlaylistSnapshotPublicKey", "__Internal")]
	NSString SPTPlaylistSnapshotPublicKey { get; }

	// extern NSString *const SPTPlaylistSnapshotNameKey;
	[Field ("SPTPlaylistSnapshotNameKey", "__Internal")]
	NSString SPTPlaylistSnapshotNameKey { get; }
}

// typedef void (^SPTPlaylistCreationCallback)(NSError *, SPTPlaylistSnapshot *);
delegate void SPTPlaylistCreationCallback (NSError arg0, SPTPlaylistSnapshot arg1);
