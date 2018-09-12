using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6> :
        MultiContainer<TData, TConfig, T1, T2, T3, T4, T5>, IMultiContainer<T1, T2, T3, T4, T5, T6>
        where TData : class, IInputData<T1, T2, T3, T4, T5, T6>
        where TConfig : class, IDataConfig
    {
        public T6 Item6 => _dataProxyContainer6.Value;

        private readonly IDataProxyContainer<T6> _dataProxyContainer6;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer6 = new DataProxyContainer<T6, TConfig>(data.ItemArray6,GetCurrentConfig());
        }

        protected override int CurrentConfigCount()
        {
            return 6;
        }

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer6.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer6.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer6.CleanUp();
        }
    }
}