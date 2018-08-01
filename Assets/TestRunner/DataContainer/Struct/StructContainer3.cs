using System;
using TestRunner.Utils;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace TestRunner.DataContainer.Struct
{
    internal class StructContainer<TConfig, T1, T2, T3> : StructContainer<TConfig, T1, T2>,
        IStructContainer<TConfig, T1, T2, T3>
        where TConfig : IWorkConfigIJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private readonly T3[] _itemArray3;

        public NativeArray<T3> Item3 { get; private set; }

        public StructContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3) : base(itemArray1, itemArray2)
        {
            _itemArray3 = itemArray3;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            if (Item3.IsCreated)
            {
                try
                {
                    Item3.Dispose();
                }
                catch (InvalidOperationException e)
                {
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item3), e.Message);
                }

                Item3 = default(NativeArray<T3>);
            }
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item3 = new NativeArray<T3>(_itemArray3, config.Allocator);
        }
    }
}