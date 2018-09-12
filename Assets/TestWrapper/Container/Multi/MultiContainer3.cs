using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2, T3> : MultiContainer<TData, TConfig, T1, T2>,
        IMultiContainer<T1, T2, T3>
        where TData : class, IInputData<T1, T2, T3>
        where TConfig : class, IDataConfig
    {
        public T3 Item3 => _dataProxyContainer3.Value;

        private readonly IDataProxyContainer<T3> _dataProxyContainer3;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer3 = new DataProxyContainer<T3, TConfig>(data.ItemArray3, GetCurrentConfig());
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