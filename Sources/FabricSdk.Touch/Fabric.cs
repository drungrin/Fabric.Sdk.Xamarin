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

        public bool Debug
        {
            get { return Platform.Fabric.SharedSDK().Debug; }
            set { Platform.Fabric.SharedSDK().Debug = value; }
        }

        public IFabric With(IKit[] kits)
        {
            Platform.Fabric.With(Array.ConvertAll(kits, i => i.ToNative()));
            return this;
        }
    }
}