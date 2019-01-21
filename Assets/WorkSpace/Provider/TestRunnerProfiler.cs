#if UNITY_EDITOR
using System;
using TestWrapper.Facades;
using TestWrapper.Facades.Info;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Provider
{
    public sealed class TestRunnerProfiler : MonoBehaviour
    {
        private const string TestNamePrefix = "TestRunner";

#pragma warning disable 649
        [Header("Delay specific frames from start"), SerializeField, Range(0, 10)]
        private int delayFrames = 3;

        [Header("Stop unity after finished test case"), SerializeField, Range(0, 10)]
        private int stopAfterFinishFrames = 5;

        [SerializeField] private TestSettings testSettings;
#pragma warning restore 649

        [NonSerialized] private TestProvider _testProvider;

        private int _currentRun;

        private void Awake()
        {
            _testProvider = new TestProvider(testSettings);
        }

        private void Update()
        {
            if (delayFrames + 1 > Time.frameCount)
            {
                return;
            }

            if (testSettings.TotalRuns > _currentRun)
            {
                foreach (var workFacade in _testProvider.WorkFacades)
                {
                    TestCase(workFacade);
                }

                _currentRun++;
            }

            if (Time.frameCount > stopAfterFinishFrames + delayFrames + 1 + testSettings.TotalRuns)
            {
                EditorApplication.isPlaying = false;
            }
        }

        private void TestCase(IWorkFacade workFacade)
        {
            workFacade.SetUp();
            BeginTracking(workFacade.Info());
            workFacade.Run();
            EndTracking();
            workFacade.CleanUp();
        }

        private void BeginTracking(IWorkWrapperInfo info)
        {
            Profiler.BeginSample($"|{TestNamePrefix}| {info}");
        }

        private void EndTracking()
        {
            Profiler.EndSample();
        }
    }
}
#endif