using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Info;
using TestWrapper.InputData;

namespace TestWrapper.Container.Multi.Base
{
    internal abstract class MultiContainer<TData, TConfig> : RefreshContainer<TConfig>, IMultiContainer
        where TData : class, IInputData
        where TConfig : class, IDataConfig
    {
        private int _dataSize;

        public int DataSize
        {
            get => _dataSize;
            set => _dataSize = value < 0 ? 0 : value;
        }

        private readonly TData _data;
        protected TData Data => _data;

        public MultiContainer(TData data, params TConfig[] config) : base(config)
        {
            _data = data;
            CheckConfigCount();
        }

        private void CheckConfigCount()
        {
            if (Configs.Length != CurrentConfigCount())
            {
                throw new Exception(
                    "Incorrect config data count, every data structure must have its own configuration");
            }
        }

        protected abstract int CurrentConfigCount();

        protected TConfig GetCurrentConfig()
        {
            return GetConfig(CurrentConfigCount() - 1);
        }

        public new IContainerInfoDataArray Info()
        {
            var containerInfoData = new List<IContainerInfoData>();
            AppendToContainerInfoData(containerInfoData);
            return new ContainerInfoDataArray(containerInfoData.ToArray());
        }

        protected abstract void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData);
    }
}