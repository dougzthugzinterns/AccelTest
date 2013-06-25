// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace AccellorometerReadTest
{
	[Register ("AccellorometerReadTestViewController")]
	partial class AccellorometerReadTestViewController
	{

		double currentMaxAccelX;
		double currentMaxAccelY;
		double currentMaxAccelZ;
		double currentMaxAvgAccel;

		[Outlet]
		MonoTouch.UIKit.UILabel accX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel accY { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel accZ { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel rotX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel rotY { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel rotZ { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel maxAccX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel maxAccY { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel maxAccZ { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel maxRotX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel maxRotY { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel maxRotZ { get; set; }

		[Action ("resetMaxValues:")]
		partial void resetMaxValues (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (accX != null) {
				accX.Dispose ();
				accX = null;
			}

			if (accY != null) {
				accY.Dispose ();
				accY = null;
			}

			if (accZ != null) {
				accZ.Dispose ();
				accZ = null;
			}

			if (rotX != null) {
				rotX.Dispose ();
				rotX = null;
			}

			if (rotY != null) {
				rotY.Dispose ();
				rotY = null;
			}

			if (rotZ != null) {
				rotZ.Dispose ();
				rotZ = null;
			}

			if (maxAccX != null) {
				maxAccX.Dispose ();
				maxAccX = null;
			}

			if (maxAccY != null) {
				maxAccY.Dispose ();
				maxAccY = null;
			}

			if (maxAccZ != null) {
				maxAccZ.Dispose ();
				maxAccZ = null;
			}

			if (maxRotX != null) {
				maxRotX.Dispose ();
				maxRotX = null;
			}

			if (maxRotY != null) {
				maxRotY.Dispose ();
				maxRotY = null;
			}

			if (maxRotZ != null) {
				maxRotZ.Dispose ();
				maxRotZ = null;
			}
		}
	}
}
