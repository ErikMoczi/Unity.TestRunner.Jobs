using System;
using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data;
using TestRunner.Container.Multi.Base;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi
{
    internal class MultiContainer<TConfig, T1> : MultiContainer<TConfig>, IMultiContainer<T1>
        where TConfig : class, IDataConfig
    {
        public T1 Item1 => _dataProxyContainer1.Value;

        private readonly Array _itemArray1;
        private readonly IDataProxyContainer<T1> _dataProxyContainer1;

        public MultiContainer(Array itemArray1, params TConfig[] config) : base(config)
        {
            _itemArray1 = itemArray1;
            MaxDataSize = itemArray1.Length;
            _dataProxyContainer1 = new DataProxyContainer<T1, TConfig>(itemArray1, GetConfig(0));
        }

        protected override int CurrentConfigCount()
        {
            return 1;
        }

        protected override void AppendToWorkerSetUp(List<IContainerSetUp> workerSetUps)
        {
            workerSetUps.Add(_dataProxyContainer1.SetUp());
        }

        protected override void CleanUpData()
        {
            _dataProxyContainer1.Dispose();
        }

        protected override void PrepareData()
        {
            _dataProxyContainer1.Init();
        }
    }
}