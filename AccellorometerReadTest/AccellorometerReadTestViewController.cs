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
			double avgaccel = 0;
			currentMaxAccelX = 0;
			currentMaxAccelY = 0;
			currentMaxAccelZ = 0;
			currentMaxAvgAccel = 0;


			_motionManager = new CMMotionManager ();
			_motionManager.StartDeviceMotionUpdates (NSOperationQueue.CurrentQueue, (data,error) =>
			{
				this.accX.Text = data.UserAcceleration.X.ToString("0.0000");
				this.accY.Text = data.UserAcceleration.Y.ToString("0.0000");
				this.accZ.Text = data.UserAcceleration.Z.ToString("0.0000");

				avgaccel = Math.Sqrt ((data.UserAcceleration.X * data.UserAcceleration.X) + 
				                      (data.UserAcceleration.Y * data.UserAcceleration.Y) +
				                      (data.UserAcceleration.Z * data.UserAcceleration.Z));
				this.rotX.Text = avgaccel.ToString("0.0000");

				if(avgaccel > currentMaxAvgAccel)
					currentMaxAvgAccel = avgaccel;
				if(data.UserAcceleration.X > currentMaxAccelX)
					currentMaxAccelX = data.UserAcceleration.X;
				if(data.UserAcceleration.Y > currentMaxAccelY)
					currentMaxAccelY = data.UserAcceleration.Y;
				if(data.UserAcceleration.Z > currentMaxAccelZ)
					currentMaxAccelZ = data.UserAcceleration.Z;

				this.rotY.Text = currentMaxAvgAccel.ToString("0.0000");
				this.maxAccX.Text = currentMaxAccelX.ToString("0.0000");
				this.maxAccY.Text = currentMaxAccelY.ToString("0.0000");
				this.maxAccZ.Text = currentMaxAccelZ.ToString("0.0000");


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

