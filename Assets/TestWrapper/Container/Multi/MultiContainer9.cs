using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        MultiContainer<TData, TConfig, T1, T2, T3, T4, T5, T6, T7, T8>,
        IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where TData : class, IInputData<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where TConfig : class, IDataConfig
    {
        public T9 Item9 => _dataProxyContainer9.Value;

        private readonly IDataProxyContainer<T9> _dataProxyContainer9;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer9 = new DataProxyContainer<T9, TConfig>(data.ItemArray9, GetCurrentConfig());
        }

        protected override int CurrentConfigCount()
        {
            return 9;
        }

        protected override void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData)
        {
            base.AppendToContainerInfoData(containerInfoData);
            containerInfoData.Add(_dataProxyContainer9.Info());
        }

        public override void SetUp()
        {
            base.SetUp();
            _dataProxyContainer9.SetUp();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            _dataProxyContainer9.CleanUp();
        }
    }
}