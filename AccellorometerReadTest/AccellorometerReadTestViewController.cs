using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreMotion;

namespace AccellorometerReadTest
{
	public partial class AccellorometerReadTestViewController : UIViewController
	{
		public AccellorometerReadTestViewController () : base ("AccellorometerReadTestViewController", null)
		{
		}

		partial void resetMaxValues (NSObject sender)
		{
			maxAccX.Text = currentMaxAccelX.ToString();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			currentMaxAccelX = 0;
			currentMaxAccelY = 0;
			currentMaxAccelZ = 0;

			currentMaxRotX = 0;
			currentMaxRotY = 0;
			currentMaxRotZ = 0;

			CMMotionManager _motionManager = new CMMotionManager ();


			_motionManager.StartAccelerometerUpdates (NSOperationQueue.CurrentQueue, (data,error) =>
			{
				this.accX.Text = data.Acceleration.X.ToString();
				this.accY.Text = data.Acceleration.Y.ToString();
				this.accZ.Text = data.Acceleration.Z.ToString();

			});


			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

