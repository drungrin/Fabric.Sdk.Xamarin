using System;
using ObjCRuntime;

[assembly: LinkWith ("libTwitterCore.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
