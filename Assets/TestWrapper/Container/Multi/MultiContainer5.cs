using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3, T4, T5> : MultiContainer<TData, TConfig, T1, T2, T3, T4>,
        IMultiContainer<T1, T2, T3, T4, T5>
        where TData : class, IInputData<T1, T2, T3, T4, T5>
        where TConfig : class, IDataConfig
    {
        public T5 Item5 => _dataProxyContainer5.Value;

        private readonly IDataProxyContainer<T5> _dataProxyContainer5;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer5 = new DataProxyContainer<T5, TConfig>(data.ItemArray5, GetCurrentConfig());
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