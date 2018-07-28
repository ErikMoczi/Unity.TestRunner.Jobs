using System;
using System.Collections.Generic;
using System.Linq;
using TestRunner.Generator.Interfaces;
using TestRunner.Utils;

namespace TestRunner.Generator
{
    internal sealed class InputDataContainer : IInputDataContainer
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
            return _dataContainer[typeof(T)][key] as T[];
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

            if (_sampleConfigs.Length != _sampleConfigs.GroupBy(item => item.Type).Count())
            {
                throw new Exception(
                    "Make sure you create data type only once. Use params to create more data for same type.");
            }
        }

        private void AllocateDataContainer()
        {
            foreach (var sampleConfig in _sampleConfigs)
            {
                AddNewConfiguration(sampleConfig);
            }
        }

        private void AddNewConfiguration(ISampleConfig sampleConfig)
        {
            var inputData = new Dictionary<string, dynamic>();
            foreach (var name in new HashSet<string>(sampleConfig.DataNames))
            {
                inputData.Add(name, ObjectCreator.CreateArray(sampleConfig.Type, _dataSize));
            }

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
    }
}