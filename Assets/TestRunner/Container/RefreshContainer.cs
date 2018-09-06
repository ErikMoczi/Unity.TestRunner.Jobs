using TestRunner.Config;

namespace TestRunner.Container
{
    internal abstract class RefreshContainer<TConfig> : BaseContainer<TConfig>, IRefreshContainer
        where TConfig : class, IBaseConfig
    {
        protected RefreshContainer(params TConfig[] config) : base(config)
        {
        }

        public abstract void Dispose();
        public abstract void Init();
    }

    internal interface IMultiConfig : IRefreshContainer
    {
    }

    internal abstract class MultiConfig<TConfig> : RefreshContainer<TConfig>, IMultiConfig
        where TConfig : class, IBaseConfig
    {
        protected MultiConfig(TConfig config) : base(config)
        {
        }
    }
}