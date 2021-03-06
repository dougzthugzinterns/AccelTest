using System;
using System.Drawing;
using System.Collections;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreMotion;
using MonoTouch.CoreLocation;

namespace AccellorometerReadTest
{
	public partial class AccellorometerReadTestViewController : UIViewController
	{
		double currentMaxAccelX;
		double currentMaxAccelY;
		double currentMaxAccelZ;
		double currentMaxAvgAccel;
		double threshold = .5;
		int eventcount = 0;
		CLLocationCoordinate2D currentCoord = new CLLocationCoordinate2D();
		ArrayList coordList = new ArrayList();
		

		bool eventInProgress = false;
		private CMMotionManager _motionManager;

		public double getCurrentLatitude(){
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10;
			if(CLLocationManager.LocationServicesEnabled){
				myLocMan.StartUpdatingLocation ();
			}
			double latitude = myLocMan.Location.Coordinate.Latitude;
			myLocMan.StartUpdatingLocation ();
			return latitude;

		}
		//Gets the Longitude of the user.
		public double getCurrentLongitude(){
			CLLocationManager myLocMan = new CLLocationManager ();
			myLocMan.DesiredAccuracy = 10;
			if(CLLocationManager.LocationServicesEnabled){
				myLocMan.StartUpdatingLocation ();
			}
			double longitude = myLocMan.Location.Coordinate.Longitude;
			myLocMan.StartUpdatingLocation ();
			return longitude;
		}

		public AccellorometerReadTestViewController () : base ("AccellorometerReadTestViewController", null)
		{
		}

		partial void resetMaxValues (NSObject sender)
		{
			currentMaxAccelX = 0;
			currentMaxAccelY = 0;
			currentMaxAccelZ = 0;
			currentMaxAvgAccel = 0;
			eventcount = 0;
			this.eventCounter.Text = "0";
			this.accX.Text = "0";
			this.accY.Text = "0";
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
			_motionManager.DeviceMotionUpdateInterval = .5;
			_motionManager.StartDeviceMotionUpdates (NSOperationQueue.CurrentQueue, (data,error) =>
			{

				//UIAccelerationValue lowPassFilteredXAcceleration = (currentXAcceleration * kLowPassFilteringFactor) + (previousLowPassFilteredXAcceleration * (1.0 - kLowPassFilteringFactor));


				this.accZ.Text = data.UserAcceleration.Z.ToString("0.0000");

				avgaccel = Math.Sqrt ((data.UserAcceleration.X * data.UserAcceleration.X) + 
				                      (data.UserAcceleration.Y * data.UserAcceleration.Y) +
				                      (data.UserAcceleration.Z * data.UserAcceleration.Z));

				if(avgaccel > threshold){
					eventInProgress = true;
				}

				else if((avgaccel < threshold)&&eventInProgress){
					eventcount++;
					this.eventCounter.Text = eventcount.ToString();
					eventInProgress = false;
					currentCoord.Latitude = getCurrentLatitude();
					currentCoord.Longitude = getCurrentLongitude();
					coordList.Add(currentCoord);

					this.accX.Text = currentCoord.Latitude.ToString();
					this.accY.Text = currentCoord.Longitude.ToString();

				}




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

