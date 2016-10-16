using System;
using ObjCRuntime;

[Native]
public enum SPTSearchQueryType : nuint
{
	Track = 0,
	Artist,
	Album,
	Playlist
}

[Native]
public enum SPTAlbumType : nuint
{
	Album,
	Single,
	Compilation,
	AppearsOn
}

[Native]
public enum SPTProduct : nuint
{
	Free,
	Unlimited,
	Premium,
	Unknown
}
