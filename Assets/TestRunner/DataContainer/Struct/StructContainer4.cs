using System;
using TestRunner.Utils;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace TestRunner.DataContainer.Struct
{
    internal class StructContainer<TConfig, T1, T2, T3, T4> : StructContainer<TConfig, T1, T2, T3>,
        IStructContainer<TConfig, T1, T2, T3, T4>
        where TConfig : IWorkConfigIJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private readonly T4[] _itemArray4;

        public NativeArray<T4> Item4 { get; private set; }

        public StructContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4) : base(itemArray1,
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
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item4), e.Message);
                }

                Item4 = default(NativeArray<T4>);
            }
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item4 = new NativeArray<T4>(_itemArray4, config.Allocator);
        }
    }
}