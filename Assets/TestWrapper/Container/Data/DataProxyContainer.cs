using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Data.Base;
using TestWrapper.Container.Info;
using TestWrapper.DataType;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace TestWrapper.Container.Data
{
    internal sealed class DataProxyContainer<T, TConfig> : DataContainer<T, TConfig>, IDataProxyContainer<T>
        where TConfig : class, IDataConfig
    {
        public new T Value => _dataWrapper.Value;

        private readonly IDataContainer<T> _dataWrapper;
        private readonly Array _data;

        public DataProxyContainer(Array data, TConfig config) : base(data, config)
        {
            _data = data;
            CheckInputArray(data);
            _dataWrapper = InitDataContainer();
        }

        private IDataContainer<T> InitDataContainer()
        {
            var type = typeof(T);
            if (type.IsArray)
            {
                return new DataContainerArray<T, IDataConfigDefault>(_data, GetConfig() as IDataConfigDefault);
            }

            if (type.IsValueType & type.Namespace == $"{nameof(Unity)}.{nameof(Unity.Collections)}")
            {
                if (DataContainerNativeArray<T, IDataConfigUnityCollection>.DataType() ==
                    type.GetGenericTypeDefinition())
                {
                    return new DataContainerNativeArray<T, IDataConfigUnityCollection>(_data,
                        GetConfig() as IDataConfigUnityCollection);
                }

                throw new Exception($"Missing implementation of {type} Unity collection");
            }

            if (type.IsValueType & type.DeclaringType?.Name == nameof(NativeConcurrentIntArray))
            {
                return new DataContainerNativeConcurrentIntArray<T, IDataConfigUnityCollection>(_data,
                    GetConfig() as IDataConfigUnityCollection);
            }

            if (type.IsValueType | type.IsClass)
            {
                return new DataContainerDefault<T, IDataConfigDefault>(_data, GetConfig() as IDataConfigDefault);
            }

            throw new Exception($"Not allowed data structure type {type}");
        }

        private void CheckInputArray(Array array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Array data used in InputData must be not null");
            }

            if (array.Rank > 1)
            {
                throw new ArgumentException(
                    $"Array data {array.GetType()} used in InputData must be single-dimensional array"
                );
            }

            var elementType = array.GetType().GetElementType();
            // ReSharper disable once PossibleNullReferenceException
            if (!elementType.IsValueType)
            {
                throw new ArgumentException($"Array data {array.GetType()} used in InputData must be value type");
            }

            if (!UnsafeUtility.IsBlittable(elementType))
            {
                throw new ArgumentException($"Array data {array.GetType()} used in InputData must be blittable");
            }
        }

        public sealed override IContainerInfoData Info()
        {
            return _dataWrapper.Info();
        }

        public override void SetUp()
        {
            _dataWrapper.SetUp();
        }

        public override void CleanUp()
        {
            try
            {
                _dataWrapper.CleanUp();
            }
            catch (InvalidOperationException e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}