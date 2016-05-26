using Foundation;

namespace FabricSdk
{
    public abstract class Kit : IKit
    {
        internal NSObject NativeObject;

        protected Kit(NSObject nativeObject)
        {
            NativeObject = nativeObject;
        }
    }

    public static class KitMixins
    {
        public static NSObject ToNative(this IKit kit)
        {
            return (kit as Kit)?.NativeObject;
        }
    }
}