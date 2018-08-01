using System;
using TestRunner.Utils;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace TestRunner.DataContainer.Struct
{
    internal class StructContainer<TConfig, T1> : DataContainer<TConfig>, IStructContainer<TConfig, T1>
        where TConfig : IWorkConfigIJob
        where T1 : struct
    {
        private readonly T1[] _itemArray1;

        public NativeArray<T1> Item1 { get; private set; }

        public StructContainer(T1[] itemArray1)
        {
            _itemArray1 = itemArray1;
            MaxDataSize = itemArray1.Length;
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
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item1), e.Message);
                }

                Item1 = default(NativeArray<T1>);
            }
        }

        protected override void PrepareData(TConfig config)
        {
            Item1 = new NativeArray<T1>(_itemArray1, config.Allocator);
        }
    }
}