using System;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.SetUp;
using TestRunner.Utils.Extensions;

namespace TestRunner.Container.Data.Base
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

        public virtual IContainerSetUp SetUp()
        {
            return new ContainerSetUp(TypeValue.GetFriendlyName(), TypeValue.Namespace, GetConfig().ToString());
        }
    }
}