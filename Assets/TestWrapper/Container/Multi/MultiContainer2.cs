using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1, T2> : MultiContainer<TData, TConfig, T1>, IMultiContainer<T1, T2>
        where TData : class, IInputData<T1, T2>
        where TConfig : class, IDataConfig
    {
        public T2 Item2 => _dataProxyContainer2.Value;

        private readonly IDataProxyContainer<T2> _dataProxyContainer2;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            _dataProxyContainer2 = new DataProxyContainer<T2, TConfig>(data.ItemArray2, GetCurrentConfig());
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