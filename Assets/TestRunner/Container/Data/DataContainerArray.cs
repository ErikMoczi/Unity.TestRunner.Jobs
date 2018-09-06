using System;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Data.Base;

namespace TestRunner.Container.Data
{
    internal sealed class DataContainerArray<T, TConfig> : DataContainer<T, TConfig>
        where TConfig : class, IDataConfigDefault
    {
        public DataContainerArray(Array data, TConfig config) : base(data, config)
        {
            // ReSharper disable once PossibleNullReferenceException
            if (!data.GetType().GetElementType().IsAssignableFrom(TypeValue.GetElementType()))
            {
                throw new ArgumentException(
                    $"Data structure of not {TypeValue} is not same type - {data.GetType().GetElementType()}"
                );
            }
        }

        public override void Dispose()
        {
            ReflectionInstance = default(T);
        }

        public override void Init()
        {
            ReflectionInstance = (T) Convert.ChangeType(Data.Clone(), TypeValue);
        }
    }
}