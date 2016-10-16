using System;

using Foundation;
using ObjCRuntime;
using CoreGraphics;
using UIKit;

namespace SpotifyMetadata.iOS
{
		[Native]
	public enum SPTSearchQueryType : ulong
	{
		Track = 0,
		Artist,
		Album,
		Playlist
	}

	[Native]
	public enum SPTAlbumType : ulong
	{
		Album,
		Single,
		Compilation,
		AppearsOn
	}

	[Native]
	public enum SPTProduct : ulong
	{
		Free,
		Unlimited,
		Premium,
		Unknown
	}
}
