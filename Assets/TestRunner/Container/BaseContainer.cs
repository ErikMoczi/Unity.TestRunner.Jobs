using System;
using TestRunner.Config;

namespace TestRunner.Container
{
    internal abstract class BaseContainer<TConfig> : IBaseContainer
        where TConfig : class, IBaseConfig
    {
        private readonly TConfig[] _configs;
        protected TConfig[] Configs => _configs;

        public BaseContainer(params TConfig[] configs)
        {
            if (configs == null | configs.Length == 0)
            {
                throw new Exception($"Internal wrong configs {typeof(TConfig)}");
            }

            foreach (var config in configs)
            {
                if (config == null)
                {
                    throw new Exception($"Missing correct config type {typeof(TConfig)}");
                }
            }

            _configs = configs;
        }

        protected TConfig GetConfig(int index = 0)
        {
            if (index < 0 | index >= _configs.Length)
            {
                throw new ArgumentException($"Internal incorrect index of configs", nameof(Configs));
            }

            return _configs[index];
        }
    }
}