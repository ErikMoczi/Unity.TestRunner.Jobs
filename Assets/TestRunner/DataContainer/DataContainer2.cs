using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal class DataContainer<T1, T2> : DataContainer<T1>, IDataContainer<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        private readonly T2[] _itemArray2;

        public NativeArray<T2> Item2 { get; private set; }

        public DataContainer(T1[] itemArray1, T2[] itemArray2) : base(itemArray1)
        {
            _itemArray2 = itemArray2;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            if (!Item2.Equals(default(NativeArray<T2>)))
            {
                Item2.Dispose();
            }
        }

        protected override void PrepareData(Allocator allocator)
        {
            base.PrepareData(allocator);
            Item2 = new NativeArray<T2>(_itemArray2, allocator);
        }
    }
}