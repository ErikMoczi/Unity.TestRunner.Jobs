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
#pragma warning disable 649
        [SerializeField] private int dataSize = 1000000;
        [SerializeField, Range(0, 1000)] private int totalRuns = 10;
        [SerializeField, Range(0, 10)] private int warmUpCount = 3;
        [SerializeField, Range(0, 10)] private int resultsPrecision = 4;
        [SerializeField] private SampleUnit sampleUnit = SampleUnit.Millisecond;
        [Header("Choose which test case to run"), SerializeField]
        private TestCaseWrapper testCaseWrapper;
#pragma warning restore 649

        public TestCaseWrapper TestCaseWrapper => testCaseWrapper;
        public int DataSize => dataSize;
        public int TotalRuns => totalRuns;
        public int WarmUpCount => warmUpCount;
        public int ResultsPrecision => resultsPrecision;
        public SampleUnit SampleUnit => sampleUnit;
    }
}