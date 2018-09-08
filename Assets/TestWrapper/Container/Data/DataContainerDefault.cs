using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data.Base;

namespace TestWrapper.Container.Data
{
    internal sealed class DataContainerDefault<T, TConfig> : DataContainer<T, TConfig>
        where TConfig : class, IDataConfigDefault
    {
        public DataContainerDefault(Array data, TConfig config) : base(data, config)
        {
            var parameters = data.GetType().GetElementType();
            var constructorInfos = TypeValue.GetConstructor(new[] {parameters});
            if (constructorInfos == null)
            {
                throw new Exception($"Missing specific constructor of type {TypeValue} with parameters {parameters}");
            }
        }

        public override void SetUp()
        {
            ReflectionInstance = (T) Activator.CreateInstance(TypeValue, Data);
        }

        public override void CleanUp()
        {
            ReflectionInstance = default(T);
        }
    }
}