using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICollection<IKit> Kits { get; } = new List<IKit>();

        public event EventHandler AfterInitialize;
        public event EventHandler BeforeInitialize;

        internal void Initialize(Context context)
        {
            BeforeInitialize?.Invoke(this, new EventArgs());

            Bindings.FabricSdk.Fabric.With(new Bindings.FabricSdk.Fabric.Builder(context)
                .Kits(Kits.Select(i => i.ToNative()).ToArray())
                .Debuggable(Debug)
                .Build());

            AfterInitialize?.Invoke(this, new EventArgs());
        }
    }

    public static class Initializer
    {
        private static readonly object InitializeLock = new object();
        private static bool _initialized;

        public static void Initialize(this IFabric fabric, Context context)
        {
            if (_initialized) return;
            lock (InitializeLock)
            {
                if (_initialized) return;

                var instance = fabric as Fabric;

                if (instance == null) return;

                instance.Initialize(context);

                _initialized = true;
            }
        }
    }
}