using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace SpotifyMetadata
{
	[Native]
public enum SPTSearchQueryType : uint
{
	Track = 0,
	Artist,
	Album,
	Playlist
}

[Native]
public enum SPTAlbumType : uint
{
	Album,
	Single,
	Compilation,
	AppearsOn
}

[Native]
public enum SPTProduct : uint
{
	Free,
	Unlimited,
	Premium,
	Unknown
}

}
