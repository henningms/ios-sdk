using System;
using System.Threading.Tasks;
using Foundation;
using SpotifyAuthentication.iOS;
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

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			SPTAuth.DefaultInstance.ClientID = "cd7cc329b689452aa17a42330f2f63c0";
			SPTAuth.DefaultInstance.RedirectURL = NSUrl.FromString("testmetadatalogin://callback");
			SPTAuth.DefaultInstance.RequestedScopes = new[] {"streaming"};

			var k = SpotifyAuthentication.iOS.Constants.SPTAuthStreamingScope;
			var loginUrl = SPTAuth.DefaultInstance.LoginURL;

			UIApplication.SharedApplication.OpenUrl(loginUrl);
		}
	}
}
