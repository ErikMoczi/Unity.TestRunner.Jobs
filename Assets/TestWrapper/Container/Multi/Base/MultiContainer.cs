using System;
using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Info;

namespace TestWrapper.Container.Multi.Base
{
    internal abstract class MultiContainer<TConfig> : RefreshContainer<TConfig>, IMultiContainer
        where TConfig : class, IDataConfig
    {
        private int _maxDataSize;
        private int _dataSize;

        public int DataSize
        {
            get => _dataSize;
            set
            {
                if (value > _maxDataSize)
                {
                    _dataSize = _maxDataSize;
                }
                else if (value < 0)
                {
                    _dataSize = 0;
                }
                else
                {
                    _dataSize = value;
                }
            }
        }

        protected int MaxDataSize
        {
            get => _maxDataSize;
            set => _dataSize = _maxDataSize = value;
        }

        public MultiContainer(params TConfig[] config) : base(config)
        {
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

        public new IContainerInfoDataArray Info()
        {
            var containerInfoData = new List<IContainerInfoData>();
            AppendToContainerInfoData(containerInfoData);
            return new ContainerInfoDataArray(containerInfoData.ToArray());
        }

        protected abstract void AppendToContainerInfoData(List<IContainerInfoData> containerInfoData);
    }
}