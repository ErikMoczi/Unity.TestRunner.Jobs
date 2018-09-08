using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;

namespace TestWrapper.Container.Multi
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

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer4.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer4.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer4.CleanUp();
        }
    }
}