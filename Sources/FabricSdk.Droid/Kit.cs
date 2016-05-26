namespace FabricSdk
{
    public abstract class Kit : IKit
    {
        internal Platform.Kit NativeKit;

        protected Kit(Platform.Kit nativeKit)
        {
            NativeKit = nativeKit;
        }
    }

    public static class KitMixins
    {
        public static Platform.Kit ToNative(this IKit kit)
        {
            return (kit as Kit)?.NativeKit;
        }
    }
}
