using System;
using TestRunner.Utils;
using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal class DataContainer<T1, T2, T3, T4> : DataContainer<T1, T2, T3>, IDataContainer<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private readonly T4[] _itemArray4;

        public NativeArray<T4> Item4 { get; private set; }

        public DataContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4) : base(itemArray1,
            itemArray2, itemArray3)
        {
            _itemArray4 = itemArray4;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            if (Item4.IsCreated)
            {
                try
                {
                    Item4.Dispose();
                }
                catch (InvalidOperationException e)
                {
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item4));
                }

                Item4 = default(NativeArray<T4>);
            }
        }

        protected override void PrepareData(Allocator allocator)
        {
            base.PrepareData(allocator);
            Item4 = new NativeArray<T4>(_itemArray4, allocator);
        }
    }
}