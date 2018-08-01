using System;
using TestRunner.Utils;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace TestRunner.DataContainer.Struct
{
    internal class StructContainer<TConfig, T1, T2> : StructContainer<TConfig, T1>, IStructContainer<TConfig, T1, T2>
        where TConfig : IWorkConfigIJob
        where T1 : struct
        where T2 : struct
    {
        private readonly T2[] _itemArray2;

        public NativeArray<T2> Item2 { get; private set; }

        public StructContainer(T1[] itemArray1, T2[] itemArray2) : base(itemArray1)
        {
            _itemArray2 = itemArray2;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            if (Item2.IsCreated)
            {
                try
                {
                    Item2.Dispose();
                }
                catch (InvalidOperationException e)
                {
                    UnityDebugLog.DisposeStructWarningLog(nameof(Item2), e.Message);
                }

                Item2 = default(NativeArray<T2>);
            }
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item2 = new NativeArray<T2>(_itemArray2, config.Allocator);
        }
    }
}