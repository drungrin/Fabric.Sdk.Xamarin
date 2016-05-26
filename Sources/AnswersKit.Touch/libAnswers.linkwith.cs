using System;
using ObjCRuntime;

[assembly: LinkWith ("libAnswers.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
