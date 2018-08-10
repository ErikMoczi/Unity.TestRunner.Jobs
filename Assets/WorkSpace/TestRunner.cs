using System;
using System.Linq;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using UnityEditor;
using UnityEngine;
using WorkSpace.Tests.Base;

namespace WorkSpace
{
    public sealed class TestRunner : MonoBehaviour
    {
        [SerializeField] private int _dataSize = 100000;
        [SerializeField] private int _totalRuns = 5;

        [Header("Delay specific frames from start")] [SerializeField] [Range(0, 10)]
        private int _delayFrames = 3;

        [Header("Pause unity after finished test case")] [SerializeField] [Range(0, 10)]
        private int _pauseAfterFinishFrames = 5;

        [Header("Choose which test case to run")] [SerializeField]
        private TestCaseWrapper _testCaseWrapper;

        private ISampleGenerator[] _sampleGenerators;
        private IInputDataContainer _inputDataContainer;
        private IWorkWrapper[] _workWrappers;
        private int _currentRun;

        private void Awake()
        {
            _sampleGenerators = InitSampleGenerator();
            _inputDataContainer = InitInputDataContainer(_sampleGenerators);
            _workWrappers = InitWorkWrappers(_sampleGenerators, _inputDataContainer);
        }

        private void Update()
        {
            if (_delayFrames + 1 > Time.frameCount)
            {
                return;
            }

            if (_totalRuns > _currentRun)
            {
                foreach (var workWrapper in _workWrappers)
                {
                    workWrapper.Run();
                }

                _currentRun++;
            }

            if (Time.frameCount > _pauseAfterFinishFrames + _delayFrames + 1 + _totalRuns)
            {
                EditorApplication.isPaused = true;
            }
        }

        private ISampleGenerator[] InitSampleGenerator()
        {
            var sampleGenerators = new ISampleGenerator[_testCaseWrapper.TotalGenerators];
            for (var i = 0; i < _testCaseWrapper.TotalGenerators; i++)
            {
                var type = Type.GetType(_testCaseWrapper.Generators[i]);
                if (type == null)
                {
                    throw new ArgumentException(
                        $"Parameter of generators has to be real class full name (using reflection), instead of {_testCaseWrapper.Generators[i]}",
                        nameof(_testCaseWrapper.Generators)
                    );
                }

                var sampleGenerator = Activator.CreateInstance(type) as ISampleGenerator;
                sampleGenerators[i] = sampleGenerator;
            }

            return sampleGenerators;
        }

        private IInputDataContainer InitInputDataContainer(ISampleGenerator[] sampleGenerators)
        {
            return new InputDataContainer(sampleGenerators.SelectMany(item => item.InitSampleConfigs()).ToArray(),
                _dataSize);
        }

        private IWorkWrapper[] InitWorkWrappers(ISampleGenerator[] sampleGenerators,
            IInputDataContainer inputDataContainer)
        {
            return sampleGenerators.SelectMany(item => item.InitWorkWrappers(inputDataContainer, _dataSize)).ToArray();
        }
    }
}