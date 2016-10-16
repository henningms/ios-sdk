using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace SpotifyMetadata.iOS.Sample
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override async void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			NSError error;

			var wat = SPTTrack.CreateRequestForTrack(new NSUrl("https://api.spotify.com/v1/tracks/0eGsygTp906u18L0Oimnem", ""), null, null, out error);
			var l = 5;
		}
	}
}
