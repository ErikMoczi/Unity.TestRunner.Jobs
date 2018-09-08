using TestWrapper.Config;

namespace TestWrapper.Container
{
    internal abstract class RefreshContainer<TConfig> : BaseContainer<TConfig>, IRefreshContainer
        where TConfig : class, IBaseConfig
    {
        protected RefreshContainer(params TConfig[] config) : base(config)
        {
        }

        public abstract void SetUp();
        public abstract void CleanUp();
    }
}