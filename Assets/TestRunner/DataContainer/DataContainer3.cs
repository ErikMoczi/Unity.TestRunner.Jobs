using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal class DataContainer<T1, T2, T3> : DataContainer<T1, T2>, IDataContainer<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private readonly T3[] _itemArray3;

        public NativeArray<T3> Item3 { get; private set; }

        public DataContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3) : base(itemArray1, itemArray2)
        {
            _itemArray3 = itemArray3;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            if (!Item3.Equals(default(NativeArray<T3>)))
            {
                Item3.Dispose();
            }
        }

        protected override void PrepareData(Allocator allocator)
        {
            base.PrepareData(allocator);
            Item3 = new NativeArray<T3>(_itemArray3, allocator);
        }
    }
}