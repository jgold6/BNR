//
//  Document.m
//  CarLot
//
//  Created by Jonathan Goldberger on 12/27/14.
//  Copyright (c) 2014 Jonathan Goldberger. All rights reserved.
//

#import "Document.h"

@interface Document ()

@end

@implementation Document

@synthesize tableView, carArrayController;

- (instancetype)init {
    self = [super init];
    if (self) {
        // Add your subclass-specific initialization here.
    }
    return self;
}

- (void)windowControllerDidLoadNib:(NSWindowController *)aController {
    [super windowControllerDidLoadNib:aController];
    // Add any code here that needs to be executed once the windowController has loaded the document's window.
}

+ (BOOL)autosavesInPlace {
    return YES;
}

- (NSString *)windowNibName {
    // Override returning the nib file name of the document
    // If you need to use a subclass of NSWindowController or if your document supports multiple NSWindowControllers, you should remove this method and override -makeWindowControllers instead.
    return @"Document";
}

- (IBAction)addCar:(id)sender {
    NSWindow *w = [tableView window];
    
    BOOL editingEnded = [w makeFirstResponder:w];
    if (!editingEnded) {
        NSLog(@"Unable to end editing");
        return;
    }
    
    NSUndoManager *undo = [self undoManager];
    
    // Has an edit already occurred?
    if ([undo groupingLevel] > 0) {
        // Close the last group
        [undo endUndoGrouping];
        // Open a new group
        [undo beginUndoGrouping];
    }
    
    // Create the object
    id p = [carArrayController newObject];
    // Add it to the content array of carArrayController
    [carArrayController addObject:p];
    // Re-sort (in case the user has sorted a column
    [carArrayController rearrangeObjects];
    // Get the sorted array
    NSArray *a = [carArrayController arrangedObjects];
    // Find the object just added
    NSUInteger row = [a indexOfObjectIdenticalTo:p];
    NSLog(@"starting edit of %@ in row %lu", p, row);
    // begin the edit in the first column
    [tableView editColumn:0 row:row withEvent:nil select:YES];
}
@end



















