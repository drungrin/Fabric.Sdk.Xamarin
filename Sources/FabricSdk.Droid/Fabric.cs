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
    }
}