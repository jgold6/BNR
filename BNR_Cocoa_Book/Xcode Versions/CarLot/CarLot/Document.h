//
//  Document.h
//  CarLot
//
//  Created by Jonathan Goldberger on 12/27/14.
//  Copyright (c) 2014 Jonathan Goldberger. All rights reserved.
//

#import <Cocoa/Cocoa.h>
#import "CarArrayController.h"

@interface Document : NSPersistentDocument
@property (strong) IBOutlet NSTableView *tableView;
@property (strong) IBOutlet CarArrayController *carArrayController;
- (IBAction)addCar:(id)sender;
@end
