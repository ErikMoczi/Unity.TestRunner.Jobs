using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data.Base;
using Unity.Collections;

namespace TestWrapper.Container.Data
{
    internal abstract class DataContainerUnityNativeCollections<T, TConfig> : DataContainer<T, TConfig>
        where TConfig : class, IDataConfigUnityCollection
    {
        private const string PropertyIsCreated = "IsCreated";
        private const string MethodDispose = "Dispose";

        private readonly Type _collection;
        protected Type Collection => _collection;

        public DataContainerUnityNativeCollections(Array data, TConfig config) : base(data, config)
        {
            _collection = InitCollection();

            if (!TypeValue.IsGenericType | TypeValue.GenericTypeArguments.Length != 1)
            {
                throw new Exception(
                    $"Data structure of {TypeValue} is not correct type - use {nameof(Unity.Collections)}"
                );
            }

            if (TypeValue.GenericTypeArguments[0] != data.GetType().GetElementType())
            {
                throw new Exception(
                    $"Data structure of {TypeValue} is not same type of InputData {data.GetType().GetElementType()}"
                );
            }

            if (_collection != TypeValue.GetGenericTypeDefinition())
            {
                throw new Exception(
                    $"Internal data structure of {TypeValue} is not same {_collection}"
                );
            }
        }

        private Type InitCollection()
        {
            return CreateCollection();
        }

        protected abstract Type CreateCollection();

        public sealed override void CleanUp()
        {
            var propertyInfo = ReflectionInstance.GetType().GetProperty(PropertyIsCreated);
            var isCreated = (bool) propertyInfo.GetValue(ReflectionInstance, null);
            if (isCreated)
            {
                var methodInfo = ReflectionInstance.GetType().GetMethod(MethodDispose);
                try
                {
                    methodInfo.Invoke(ReflectionInstance, null);
                }
                catch (InvalidOperationException e)
                {
                    throw new InvalidOperationException(
                        "Try don't Dispose manually data of job." +
                        $" Also don't use attribute {nameof(DeallocateOnJobCompletionAttribute)} on struct {ReflectionInstance}." +
                        "\nLet the system automatically dispose data." +
                        $"\n{e.Message}"
                    );
                }

                ReflectionInstance = default(T);
            }
        }
    }
}