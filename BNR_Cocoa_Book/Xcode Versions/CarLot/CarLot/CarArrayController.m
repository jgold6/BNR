//
//  CarArrayController.m
//  CarLot
//
//  Created by Jonathan Goldberger on 12/27/14.
//  Copyright (c) 2014 Jonathan Goldberger. All rights reserved.
//

#import "CarArrayController.h"

@implementation CarArrayController

- (id)newObject
{
    id newObj = [super newObject];
    NSDate *now = [NSDate date];
    [newObj setValue:now forKey:@"datePurchased"];
    return newObj;
}

@end
