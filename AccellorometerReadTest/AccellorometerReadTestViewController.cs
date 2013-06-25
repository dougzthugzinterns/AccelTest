using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreMotion;

namespace AccellorometerReadTest
{
	public partial class AccellorometerReadTestViewController : UIViewController


	{

		private CMMotionManager _motionManager;
		int gravity;
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

			_motionManager = new CMMotionManager ();
			_motionManager.StartAccelerometerUpdates (NSOperationQueue.CurrentQueue, (data,error) =>
			{
				this.accX.Text = data.Acceleration.X.ToString("0.0000");
				this.accY.Text = data.Acceleration.Y.ToString("0.0000");
				this.accZ.Text = data.Acceleration.Z.ToString("0.0000");

				this.maxAccX.Text = Math.Sqrt ((data.Acceleration.X * data.Acceleration.X) + 
				                               (data.Acceleration.Y * data.Acceleration.Y) +
				                               (data.Acceleration.Z * data.Acceleration.Z)).ToString("0.0000");
			

			});


			// Perform any additional setup after loading the view, typically from a nib.
		}
		public override void ViewDidUnload()
		{
			base.ViewDidUnload();

			ReleaseDesignerOutlets();
		}
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

