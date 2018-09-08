using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;

namespace TestWrapper.Container.Multi
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

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            containerInfoData.Add(_dataProxyContainer1.Info());
        }

        public override void SetUp()
        {
            _dataProxyContainer1.SetUp();
        }

        public override void CleanUp()
        {
            _dataProxyContainer1.CleanUp();
        }
    }
}