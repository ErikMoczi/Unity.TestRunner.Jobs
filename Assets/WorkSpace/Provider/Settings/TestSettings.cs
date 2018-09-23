using Unity.PerformanceTesting;
using UnityEditor;
using UnityEngine;
using WorkSpace.Provider.Containers;

namespace WorkSpace.Provider.Settings
{
    [CreateAssetMenu(menuName = "TestRunner/Test Settings", fileName = nameof(TestSettings))]
    public sealed class TestSettings :
#if UNITY_EDITOR
        ScriptableSingleton<TestSettings>
#else
        ScriptableObject
#endif
        , ITestSettings
    {
        [SerializeField] private int _dataSize = 1000000;
        [SerializeField, Range(0, 1000)] private int _totalRuns = 10;
        [SerializeField, Range(0, 10)] private int _warmUpCount = 3;
        [SerializeField, Range(0, 10)] private int _resultsPrecision = 4;
        [SerializeField] private SampleUnit _sampleUnit = SampleUnit.Millisecond;

        [Header("Choose which test case to run")] [SerializeField]
        private TestCaseWrapper _testCaseWrapper;

        public TestCaseWrapper TestCaseWrapper => _testCaseWrapper;
        public int DataSize => _dataSize;
        public int TotalRuns => _totalRuns;
        public int WarmUpCount => _warmUpCount;
        public int ResultsPrecision => _resultsPrecision;
        public SampleUnit SampleUnit => _sampleUnit;
    }
}