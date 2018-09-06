using System;
using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi.Base
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

        public IContainerSetUp[] SetUp()
        {
            var workerSetUps = new List<IContainerSetUp>();
            AppendToWorkerSetUp(workerSetUps);
            return workerSetUps.ToArray();
        }

        protected abstract void AppendToWorkerSetUp(List<IContainerSetUp> workerSetUps);

        public sealed override void Init()
        {
            CleanUpData();
            PrepareData();
        }

        public sealed override void Dispose()
        {
            CleanUpData();
        }

        protected abstract void CleanUpData();

        protected abstract void PrepareData();
    }
}