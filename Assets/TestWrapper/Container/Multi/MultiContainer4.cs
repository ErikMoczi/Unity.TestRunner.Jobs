using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3, T4> : MultiContainer<TData, TConfig, T1, T2, T3>,
        IMultiContainer<T1, T2, T3, T4>
        where TData : class, IInputData<T1, T2, T3, T4>
        where TConfig : class, IDataConfig
    {
        public T4 Item4 => _dataProxyContainer4.Value;

        private readonly IDataProxyContainer<T4> _dataProxyContainer4;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer4 = new DataProxyContainer<T4, TConfig>(data.ItemArray4, GetCurrentConfig());
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