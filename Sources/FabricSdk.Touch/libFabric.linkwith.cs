using ObjCRuntime;

[assembly: LinkWith ("libFabric.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
