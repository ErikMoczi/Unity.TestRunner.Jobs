using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data;
using TestWrapper.Container.Info;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi
{
    internal class MultiContainer<TData, TConfig, T1> : MultiContainer<TData, TConfig>, IMultiContainer<T1>
        where TData : class, IInputData<T1>
        where TConfig : class, IDataConfig
    {
        public T1 Item1 => _dataProxyContainer1.Value;

        private readonly IDataProxyContainer<T1> _dataProxyContainer1;

        public MultiContainer(TData data, params TConfig[] config) : base(data, config)
        {
            DataSize = data.ItemArray1.Length;
            _dataProxyContainer1 = new DataProxyContainer<T1, TConfig>(data.ItemArray1, GetCurrentConfig());
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