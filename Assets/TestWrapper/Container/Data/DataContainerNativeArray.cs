using System;
using TestWrapper.Config.Data.Interfaces;
using Unity.Collections;

namespace TestWrapper.Container.Data
{
    internal sealed class DataContainerNativeArray<T, TConfig> : DataContainerUnityNativeCollections<T, TConfig>
        where TConfig : class, IDataConfigUnityCollection
    {
        public DataContainerNativeArray(Array data, TConfig config) : base(data, config)
        {
        }

        public override void SetUp()
        {
            var genericType = Collection.MakeGenericType(TypeValue.GetGenericArguments()[0]);
            ReflectionInstance = (T) Activator.CreateInstance(genericType, Data, GetConfig().Allocator);
        }

        public static Type DataType()
        {
            return typeof(NativeArray<>);
        }

        protected override Type CreateCollection()
        {
            return DataType();
        }
    }
}