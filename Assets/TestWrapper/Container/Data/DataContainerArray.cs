using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data.Base;

namespace TestWrapper.Container.Data
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

        public override void SetUp()
        {
            ReflectionInstance = (T) Data.Clone();
        }

        public override void CleanUp()
        {
            ReflectionInstance = default(T);
        }
    }
}