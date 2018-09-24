using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data.Base;
using TestWrapper.DataType;

namespace TestWrapper.Container.Data
{
    internal class DataContainerNativeConcurrentIntArray<T, TConfig> : DataContainer<T, TConfig>
        where TConfig : class, IDataConfigUnityCollection
    {
        private const string PropertyIsCreated = "IsCreated";
        private const string MethodDispose = "Dispose";

        private readonly Type _collection = typeof(NativeConcurrentIntArray);
        private NativeConcurrentIntArray _nativeConcurrentIntArray;

        public DataContainerNativeConcurrentIntArray(Array data, TConfig config) : base(data, config)
        {
        }

        public override void SetUp()
        {
            _nativeConcurrentIntArray =
                (NativeConcurrentIntArray) Activator.CreateInstance(_collection, Data.Length, GetConfig().Allocator);
            var methodInfo = _collection.GetMethod("ToConcurrent");
            var instance = methodInfo.Invoke(_nativeConcurrentIntArray, null);
            ReflectionInstance = (T) instance;
        }

        public override void CleanUp()
        {
            var propertyInfo = _nativeConcurrentIntArray.GetType().GetProperty(PropertyIsCreated);
            var isCreated = (bool) propertyInfo.GetValue(_nativeConcurrentIntArray, null);
            if (isCreated)
            {
                var methodInfo = _nativeConcurrentIntArray.GetType().GetMethod(MethodDispose);
                methodInfo.Invoke(_nativeConcurrentIntArray, null);
                _nativeConcurrentIntArray = default;
                ReflectionInstance = default(T);
            }
        }
    }
}