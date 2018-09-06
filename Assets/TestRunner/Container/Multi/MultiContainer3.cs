using System;
using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data;
using TestRunner.Container.Multi.Base;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi
{
    internal class MultiContainer<TConfig, T1, T2, T3> : MultiContainer<TConfig, T1, T2>, IMultiContainer<T1, T2, T3>
        where TConfig : class, IDataConfig
    {
        public T3 Item3 => _dataProxyContainer3.Value;

        private readonly Array _itemArray3;
        private readonly IDataProxyContainer<T3> _dataProxyContainer3;

        public MultiContainer(Array itemArray1, Array itemArray2, Array itemArray3, params TConfig[] config) : base(
            itemArray1, itemArray2, config)
        {
            _itemArray3 = itemArray3;
            _dataProxyContainer3 = new DataProxyContainer<T3, TConfig>(itemArray3, GetConfig(2));
        }

        protected override int CurrentConfigCount()
        {
            return 3;
        }

        protected override void AppendToWorkerSetUp(List<IContainerSetUp> workerSetUps)
        {
            base.AppendToWorkerSetUp(workerSetUps);
            workerSetUps.Add(_dataProxyContainer3.SetUp());
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            _dataProxyContainer3.Dispose();
        }

        protected override void PrepareData()
        {
            base.PrepareData();
            _dataProxyContainer3.Init();
        }
    }
}