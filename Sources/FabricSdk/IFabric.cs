using System.Collections.Generic;

namespace FabricSdk
{
    public interface IFabric
    {
        bool Debug { get; set; }
        ICollection<IKit> Kits { get; }
    }
}