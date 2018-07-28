using System;
using TestRunner.Utils;
using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal class DataContainer<T1> : DataContainer, IDataContainer<T1>
        where T1 : struct
    {
        private readonly T1[] _itemArray1;
        private readonly int _maxDataSize;
        private int _dataSize;

        public int DataSize
        {
            get => _dataSize;
            set
            {
                if (value > _maxDataSize)
                {
                    _dataSize = _maxDataSize;
                }
                else if (value < 0)
                {
                    _dataSize = 0;
                }
                else
                {
                    _dataSize = value;
                }
            }
        }

        public NativeArray<T1> Item1 { get; private set; }

        public DataContainer(T1[] itemArray1)
        {
            _itemArray1 = itemArray1;
            _maxDataSize = _dataSize = itemArray1.Length;
        }

        protected override void CleanUpData()
        {
            if (Item1.IsCreated)
            {
                try
                {
                    Item1.Dispose();
                }
                catch (InvalidOperationException e)
                {
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item1));
                }

                Item1 = default(NativeArray<T1>);
            }
        }

        protected override void PrepareData(Allocator allocator)
        {
            Item1 = new NativeArray<T1>(_itemArray1, allocator);
        }
    }
}