using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;

namespace TestWrapper.Container.Multi
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

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer3.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer3.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer3.CleanUp();
        }
    }
}