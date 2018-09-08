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
        [SerializeField] private int _totalRuns = 10;

        [Header("Choose which test case to run")] [SerializeField]
        private TestCaseWrapper _testCaseWrapper;

        public TestCaseWrapper TestCaseWrapper => _testCaseWrapper;
        public int DataSize => _dataSize;
        public int TotalRuns => _totalRuns;
    }
}