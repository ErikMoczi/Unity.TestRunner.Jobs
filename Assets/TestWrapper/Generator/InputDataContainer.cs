using System;
using System.Collections.Generic;
using System.Linq;
using TestWrapper.Generator.Interfaces;
using TestWrapper.Utils;

namespace TestWrapper.Generator
{
    public sealed class InputDataContainer : IInputDataContainer
    {
        private readonly int _dataSize;
        private readonly ISampleConfig[] _sampleConfigs;

        private readonly Dictionary<Type, Dictionary<string, dynamic>> _dataContainer =
            new Dictionary<Type, Dictionary<string, dynamic>>();

        public InputDataContainer(ISampleConfig[] sampleConfigs, int dataSize)
        {
            _sampleConfigs = sampleConfigs;
            _dataSize = dataSize;
            InitDataContainer();
        }

        public T[] GetData<T>(string key) where T : struct
        {
            _dataContainer.TryGetValue(typeof(T), out var type);
            if (type != null)
            {
                type.TryGetValue(key, out var value);
                if (value is T[] variable)
                {
                    return variable;
                }

                throw new Exception($"Missing correct key {key} of data type {typeof(T)}");
            }

            throw new Exception($"Missing correct data type {typeof(T)}");
        }

        private void InitDataContainer()
        {
            CheckSampleConfig();
            AllocateDataContainer();
            FillWithData();
        }

        private void CheckSampleConfig()
        {
            if (_sampleConfigs == null)
            {
                throw new NullReferenceException("Missing sample configuration");
            }
        }

        private void AllocateDataContainer()
        {
            foreach (var sampleConfig in CleanUpConfiguration(_sampleConfigs))
            {
                AddNewConfiguration(sampleConfig);
            }
        }

        private void AddNewConfiguration(ISampleConfig sampleConfig)
        {
            var inputData = sampleConfig.DataNames.ToDictionary<string, string, dynamic>(
                name => name,
                name => ObjectCreator.CreateArray(sampleConfig.Type, _dataSize)
            );

            _dataContainer.Add(sampleConfig.Type, inputData);
        }

        private void FillWithData()
        {
            for (var i = 0; i < _dataSize; i++)
            {
                FillDataByIndex(i);
            }
        }

        private void FillDataByIndex(int index)
        {
            foreach (var typeSetuPair in _dataContainer)
            {
                var type = typeSetuPair.Key;
                foreach (var inputDataName in typeSetuPair.Value.Keys)
                {
                    Dynamics.FillDataByType(type, inputDataName, index, typeSetuPair.Value);
                }
            }
        }

        private static IEnumerable<ISampleConfig> CleanUpConfiguration(ISampleConfig[] sampleConfigs)
        {
            var uniqueType = sampleConfigs.GroupBy(item => item.Type).ToList();

            if (sampleConfigs.Length == uniqueType.Count) return sampleConfigs;
            {
                var newSampleConfigs = new ISampleConfig[uniqueType.Count];
                var correctData = uniqueType.Where(item => item.Count() == 1).Select(item => item.First()).ToArray();
                var duplicateData = uniqueType.Where(item => item.Count() > 1).Select(item => item);

                var i = 0;
                for (; i < correctData.Length; i++)
                {
                    newSampleConfigs[i] = correctData[i];
                }

                foreach (var sampleConfig in duplicateData)
                {
                    var dataNames = sampleConfig.GroupBy(item => item.DataNames).SelectMany(item => item.Key).Distinct()
                        .ToArray();

                    newSampleConfigs[i] = new SampleConfig(sampleConfig.First().Type, dataNames);
                    i++;
                }

                sampleConfigs = newSampleConfigs;
            }

            return sampleConfigs;
        }
    }
}