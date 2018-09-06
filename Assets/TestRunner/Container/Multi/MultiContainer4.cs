using System;
using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data;
using TestRunner.Container.Multi.Base;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi
{
    internal class MultiContainer<TConfig, T1, T2, T3, T4> : MultiContainer<TConfig, T1, T2, T3>,
        IMultiContainer<T1, T2, T3, T4>
        where TConfig : class, IDataConfig
    {
        public T4 Item4 => _dataProxyContainer4.Value;

        private readonly Array _itemArray4;
        private readonly IDataProxyContainer<T4> _dataProxyContainer4;

        public MultiContainer(Array itemArray1, Array itemArray2, Array itemArray3, Array itemArray4,
            params TConfig[] config) : base(itemArray1, itemArray2, itemArray3, config)
        {
            _itemArray4 = itemArray4;
            _dataProxyContainer4 = new DataProxyContainer<T4, TConfig>(itemArray4, GetConfig(3));
        }

        protected override int CurrentConfigCount()
        {
            return 4;
        }

        protected override void AppendToWorkerSetUp(List<IContainerSetUp> workerSetUps)
        {
            base.AppendToWorkerSetUp(workerSetUps);
            workerSetUps.Add(_dataProxyContainer4.SetUp());
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            _dataProxyContainer4.Dispose();
        }

        protected override void PrepareData()
        {
            base.PrepareData();
            _dataProxyContainer4.Init();
        }
    }
}