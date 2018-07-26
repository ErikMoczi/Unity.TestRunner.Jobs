using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal abstract class DataContainer : IDataContainer
    {
        public void Init(Allocator allocator)
        {
            CleanUpData();
            PrepareData(allocator);
        }

        public void Dispose()
        {
            CleanUpData();
        }

        protected abstract void CleanUpData();

        protected abstract void PrepareData(Allocator allocator);
    }
}