using System;
using System.Linq;
using Android.App;
using Android.Content;

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
            Bindings.FabricSdk.Fabric.With(new Bindings.FabricSdk.Fabric.Builder(Application.Context)
                .Kits(kits.Select(i => i.ToNative()).ToArray())
                .Debuggable(Debug)
                .Build());
            return this;
        }
    }

    public static class FabricMixins
    {
        public static IFabric With(this IFabric fabric, Context context, IKit[] kits)
        {
            Bindings.FabricSdk.Fabric.With(new Bindings.FabricSdk.Fabric.Builder(context)
                .Kits(kits.Select(i => i.ToNative()).ToArray())
                .Debuggable(fabric.Debug)
                .Build());
            return fabric;
        }
    }
}