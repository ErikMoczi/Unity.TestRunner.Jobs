using System;
using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data;
using TestRunner.Container.Multi.Base;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi
{
    internal class MultiContainer<TConfig, T1, T2, T3, T4, T5> : MultiContainer<TConfig, T1, T2, T3, T4>,
        IMultiContainer<T1, T2, T3, T4, T5>
        where TConfig : class, IDataConfig
    {
        public T5 Item5 => _dataProxyContainer5.Value;

        private readonly Array _itemArray5;
        private readonly IDataProxyContainer<T5> _dataProxyContainer5;

        public MultiContainer(Array itemArray1, Array itemArray2, Array itemArray3, Array itemArray4, Array itemArray5,
            params TConfig[] config) : base(itemArray1, itemArray2, itemArray3, itemArray4, config)
        {
            _itemArray5 = itemArray5;
            _dataProxyContainer5 = new DataProxyContainer<T5, TConfig>(itemArray5, GetConfig(4));
        }

        protected override int CurrentConfigCount()
        {
            return 5;
        }

        protected override void AppendToWorkerSetUp(List<IContainerSetUp> workerSetUps)
        {
            base.AppendToWorkerSetUp(workerSetUps);
            workerSetUps.Add(_dataProxyContainer5.SetUp());
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            _dataProxyContainer5.Dispose();
        }

        protected override void PrepareData()
        {
            base.PrepareData();
            _dataProxyContainer5.Init();
        }
    }
}