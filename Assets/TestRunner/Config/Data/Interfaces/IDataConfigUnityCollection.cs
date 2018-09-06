using Unity.Collections;

namespace TestRunner.Config.Data.Interfaces
{
    public interface IDataConfigUnityCollection : IDataConfig
    {
        Allocator Allocator { get; }
    }
}