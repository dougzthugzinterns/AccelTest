// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <UIKit/UIKit.h>
#import <MapKit/MapKit.h>
#import <Foundation/Foundation.h>
#import <CoreGraphics/CoreGraphics.h>


@interface AccellorometerReadTestViewController : UIViewController {
	UILabel *_accX;
	UILabel *_accY;
	UILabel *_accZ;
	UILabel *_rotX;
	UILabel *_rotY;
	UILabel *_rotZ;
	UILabel *_maxAccX;
	UILabel *_maxAccY;
	UILabel *_maxAccZ;
	UILabel *_maxRotX;
	UILabel *_maxRotY;
	UILabel *_maxRotZ;
	UILabel *_eventCounter;
}

@property (nonatomic, retain) IBOutlet UILabel *accX;

@property (nonatomic, retain) IBOutlet UILabel *accY;

@property (nonatomic, retain) IBOutlet UILabel *accZ;

@property (nonatomic, retain) IBOutlet UILabel *rotX;

@property (nonatomic, retain) IBOutlet UILabel *rotY;

@property (nonatomic, retain) IBOutlet UILabel *rotZ;

@property (nonatomic, retain) IBOutlet UILabel *maxAccX;

@property (nonatomic, retain) IBOutlet UILabel *maxAccY;

@property (nonatomic, retain) IBOutlet UILabel *maxAccZ;

@property (nonatomic, retain) IBOutlet UILabel *maxRotX;

@property (nonatomic, retain) IBOutlet UILabel *maxRotY;

@property (nonatomic, retain) IBOutlet UILabel *maxRotZ;

@property (nonatomic, retain) IBOutlet UILabel *eventCounter;

- (IBAction)resetMaxValues:(id)sender;

@end
