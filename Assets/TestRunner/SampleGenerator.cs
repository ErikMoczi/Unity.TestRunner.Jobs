﻿using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using UnityEngine;

namespace TestRunner
{
    public abstract class SampleGenerator : MonoBehaviour
    {
        [SerializeField] private int _dataSize = 10;
        [SerializeField] private int _totalRuns = 10;

        protected int DataSize => _dataSize;
        protected int TotalRuns => _totalRuns;

        private IInputDataContainer _inputDataContainer;
        private IWorkWrapper[] _workWrappers;
        private int _currentRun;

        protected virtual void Awake()
        {
            _inputDataContainer = new InputDataContainer(InitSampleConfigs(), _dataSize);
            _workWrappers = InitWorkWrappers();
        }

        protected virtual void Update()
        {
            if (_totalRuns > _currentRun)
            {
                foreach (var workWrapper in _workWrappers)
                {
                    workWrapper.Run();
                }

                _currentRun++;
            }
        }

        protected T[] GetData<T>(string key) where T : struct
        {
            return _inputDataContainer.GetData<T>(key);
        }

        protected abstract ISampleConfig[] InitSampleConfigs();

        protected abstract IWorkWrapper[] InitWorkWrappers();
    }
}