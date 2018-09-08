using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;

namespace TestWrapper.Container.Multi
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

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer2.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer2.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer2.CleanUp();
        }
    }
}