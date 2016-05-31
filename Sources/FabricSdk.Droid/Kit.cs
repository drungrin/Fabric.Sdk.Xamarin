namespace FabricSdk
{
    public abstract class Kit : IKit
    {
        internal Bindings.FabricSdk.Kit NativeKit;

        protected Kit(Bindings.FabricSdk.Kit nativeKit)
        {
            NativeKit = nativeKit;
        }
    }

    public static class KitMixins
    {
        public static Bindings.FabricSdk.Kit ToNative(this IKit kit)
        {
            return (kit as Kit)?.NativeKit;
        }
    }
}
