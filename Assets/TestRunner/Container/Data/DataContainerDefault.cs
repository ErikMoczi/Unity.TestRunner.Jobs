using System;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data.Base;

namespace TestRunner.Container.Data
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

        public override void Dispose()
        {
            ReflectionInstance = default(T);
        }

        public override void Init()
        {
            ReflectionInstance = (T) Activator.CreateInstance(TypeValue, Data);
        }
    }
}