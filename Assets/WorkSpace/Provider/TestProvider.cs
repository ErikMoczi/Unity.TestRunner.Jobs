using System;
using System.Linq;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Provider
{
    public sealed class TestProvider
    {
        public IWorkFacade[] WorkFacades => _workFacades;

        private readonly ITestSettings _testSettings;
        private readonly IWorkFacade[] _workFacades;

        public TestProvider(ITestSettings testSettings)
        {
            _testSettings = testSettings;
            _workFacades = InitWorkFacades();
        }

        private IWorkFacade[] InitWorkFacades()
        {
            var sampleGenerators = InitSampleGenerators();
            var inputDataContainer = InitInputDataContainer(ref sampleGenerators);
            return GetWorkFacades(sampleGenerators, inputDataContainer);
        }

        private ISampleGenerator[] InitSampleGenerators()
        {
            var sampleGenerators = new ISampleGenerator[_testSettings.TestCaseWrapper.TotalGenerators];
            for (var i = 0; i < _testSettings.TestCaseWrapper.TotalGenerators; i++)
            {
                var type = Type.GetType(_testSettings.TestCaseWrapper.Generators[i]);
                if (type == null)
                {
                    throw new ArgumentException(
                        $"Parameter of generators has to be real class full name (using reflection), instead of {_testSettings.TestCaseWrapper.Generators[i]}",
                        nameof(_testSettings.TestCaseWrapper.Generators)
                    );
                }

                var sampleGenerator = Activator.CreateInstance(type) as ISampleGenerator;
                sampleGenerators[i] = sampleGenerator;
            }

            return sampleGenerators;
        }

        private IInputDataContainer InitInputDataContainer(ref ISampleGenerator[] sampleGenerators)
        {
            return new InputDataContainer(sampleGenerators.SelectMany(item => item.InitSampleConfigs()).ToArray(),
                _testSettings.DataSize);
        }

        private IWorkFacade[] GetWorkFacades(ISampleGenerator[] sampleGenerators,
            IInputDataContainer inputDataContainer)
        {
            return sampleGenerators.SelectMany(item => item.InitWorkFacades(inputDataContainer, _testSettings.DataSize))
                .ToArray();
        }
    }
}