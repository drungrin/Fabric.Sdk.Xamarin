using System;
using ObjCRuntime;

[assembly: LinkWith ("libCrashlytics.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, LinkerFlags = "-lstdc++ -lz")]
