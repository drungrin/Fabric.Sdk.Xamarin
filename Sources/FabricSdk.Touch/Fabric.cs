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
            get { return Bindings.FabricSdk.Fabric.SharedSDK().Debug; }
            set { Bindings.FabricSdk.Fabric.SharedSDK().Debug = value; }
        }

        public IFabric With(IKit[] kits)
        {
            Bindings.FabricSdk.Fabric.With(Array.ConvertAll(kits, i => i.ToNative()));
            return this;
        }
    }
}