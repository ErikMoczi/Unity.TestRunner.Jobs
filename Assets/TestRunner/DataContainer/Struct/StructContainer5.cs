using System;
using TestRunner.Utils;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace TestRunner.DataContainer.Struct
{
    internal class StructContainer<TConfig, T1, T2, T3, T4, T5> : StructContainer<TConfig, T1, T2, T3, T4>,
        IStructContainer<TConfig, T1, T2, T3, T4, T5>
        where TConfig : IWorkConfigIJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        private readonly T5[] _itemArray5;

        public NativeArray<T5> Item5 { get; private set; }

        public StructContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5) :
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
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item5), e.Message);
                }

                Item5 = default(NativeArray<T5>);
            }
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item5 = new NativeArray<T5>(_itemArray5, config.Allocator);
        }
    }
}