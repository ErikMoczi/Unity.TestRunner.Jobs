using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Info;
using TestWrapper.Utils.Extensions;

namespace TestWrapper.Container.Data.Base
{
    internal abstract class DataContainer<T, TConfig> : RefreshContainer<TConfig>, IDataContainer<T>
        where TConfig : class, IDataConfig
    {
        public T Value => ReflectionInstance;
        protected T ReflectionInstance;

        protected readonly Array Data;
        protected Type TypeValue => typeof(T);

        public DataContainer(Array data, TConfig config) : base(config)
        {
            Data = data;
        }

        public new virtual IContainerInfoData Info()
        {
            return new ContainerInfoData(TypeValue.GetFriendlyName(), TypeValue.Namespace, GetConfig().ToString());
        }
    }
}