using System;
using ObjCRuntime;

[assembly: LinkWith ("libCrashlytics.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, ForceLoad = true, SmartLink =true, LinkerFlags = "-lc++ -lz")]
