using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer
{
    internal abstract class DataContainer<TConfig> : IDataContainer<TConfig>
        where TConfig : IWorkConfig
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

        public void Init(TConfig config)
        {
            CleanUpData();
            PrepareData(config);
        }

        public void Dispose()
        {
            CleanUpData();
        }

        protected abstract void CleanUpData();

        protected abstract void PrepareData(TConfig config);
    }
}