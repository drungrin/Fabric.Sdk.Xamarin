namespace FabricSdk
{
    public interface IFabric
    {
        bool Debug { get; set; }
        IFabric With(IKit[] kits);
    }
}