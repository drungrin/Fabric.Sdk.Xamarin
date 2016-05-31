using System;
using ObjCRuntime;

[assembly: LinkWith ("libDigitsKit.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
