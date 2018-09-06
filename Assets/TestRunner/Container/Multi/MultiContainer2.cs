using System;
using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data;
using TestRunner.Container.Multi.Base;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi
{
    internal class MultiContainer<TConfig, T1, T2> : MultiContainer<TConfig, T1>, IMultiContainer<T1, T2>
        where TConfig : class, IDataConfig
    {
        public T2 Item2 => _dataProxyContainer2.Value;

        private readonly Array _itemArray2;
        private readonly IDataProxyContainer<T2> _dataProxyContainer2;

        public MultiContainer(Array itemArray1, Array itemArray2, params TConfig[] config) : base(itemArray1, config)
        {
            _itemArray2 = itemArray2;
            _dataProxyContainer2 = new DataProxyContainer<T2, TConfig>(itemArray2, GetConfig(1));
        }

        protected override int CurrentConfigCount()
        {
            return 2;
        }

        protected override void AppendToWorkerSetUp(List<IContainerSetUp> workerSetUps)
        {
            base.AppendToWorkerSetUp(workerSetUps);
            workerSetUps.Add(_dataProxyContainer2.SetUp());
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            _dataProxyContainer2.Dispose();
        }

        protected override void PrepareData()
        {
            base.PrepareData();
            _dataProxyContainer2.Init();
        }
    }
}