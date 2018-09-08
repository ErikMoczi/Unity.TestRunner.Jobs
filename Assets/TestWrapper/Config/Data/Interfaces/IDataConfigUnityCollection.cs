using Unity.Collections;

namespace TestWrapper.Config.Data.Interfaces
{
    public interface IDataConfigUnityCollection : IDataConfig
    {
        Allocator Allocator { get; }
    }
}