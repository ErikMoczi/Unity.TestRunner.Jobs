using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;

namespace TestWrapper.Container.Multi
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

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer5.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer5.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer5.CleanUp();
        }
    }
}