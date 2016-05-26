using System.Reflection;
using System.Runtime.CompilerServices;

using Foundation;

// This attribute allows you to mark your assemblies as “safe to link”.
// When the attribute is present, the linker—if enabled—will process the assembly
// even if you’re using the “Link SDK assemblies only” option, which is the default for device builds.

[assembly: LinkerSafe]

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle("FabricSdk.Touch")]
[assembly: AssemblyDescription("Fabric provides developers with the tools they need to build the best apps. Developed and maintained by Twitter and the team that built Crashlytics, Fabric provides an easy way to manage all your SDKs so that you’ll never have to worry about tedious configurations or juggling different accounts. We let you get right into coding and building the next big app.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("FabricSdk.Touch")]
[assembly: AssemblyCopyright("Copyright © Luís Michel Silva Moreira")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
