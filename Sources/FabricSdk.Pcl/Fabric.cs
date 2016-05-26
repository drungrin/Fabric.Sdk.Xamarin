using System;

namespace FabricSdk
{
    public sealed class Fabric : IFabric
    {
        private static readonly Lazy<Fabric> LazyInstance = new Lazy<Fabric>(() => new Fabric());

        private Fabric()
        {
            
        }

        public static IFabric Instance => LazyInstance.Value;

        public bool Debug { get; set; }       

        public IFabric With(IKit[] kits)
        {
            throw new PlatformNotSupportedException("The PCL build of Fabric is being linked which probably means you need to use NuGet or otherwise link a platform-specific Fabric.Platform.dll to your main application.");
        }
    }
}