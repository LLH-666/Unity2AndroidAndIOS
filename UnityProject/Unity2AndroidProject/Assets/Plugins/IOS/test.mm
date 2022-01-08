//
//  test.m
//  Unity-iPhone
//
//  Created by LLH on 2022/1/8.
//

#import <Foundation/Foundation.h>

extern "C"{
    void IOSLog(const char *message);
}

void IOSLog(const char *message){
    NSString *str=[[NSString alloc]initWithUTF8String:message];
    NSLog(str);
    
    UnitySendMessage("Main","IOSToUnity",str.UTF8String);
}
