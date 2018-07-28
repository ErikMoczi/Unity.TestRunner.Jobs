using System;
using TestRunner.Utils;
using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal class DataContainer<T1, T2, T3, T4, T5> : DataContainer<T1, T2, T3, T4>, IDataContainer<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        private readonly T5[] _itemArray5;

        public NativeArray<T5> Item5 { get; private set; }

        public DataContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5) :
            base(itemArray1, itemArray2, itemArray3, itemArray4)
        {
            _itemArray5 = itemArray5;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            if (Item5.IsCreated)
            {
                try
                {
                    Item5.Dispose();
                }
                catch (InvalidOperationException e)
                {
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item5));
                }

                Item5 = default(NativeArray<T5>);
            }
        }

        protected override void PrepareData(Allocator allocator)
        {
            base.PrepareData(allocator);
            Item5 = new NativeArray<T5>(_itemArray5, allocator);
        }
    }
}