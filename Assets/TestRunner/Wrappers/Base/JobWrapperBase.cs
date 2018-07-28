using System;
using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using Unity.Collections;
using UnityEngine.Profiling;

namespace TestRunner.Wrappers.Base
{
    internal abstract class JobWrapperBase<TDataContainer, TData, TJob> : IJobWrapperBase
        where TDataContainer : class, IDataContainer
        where TData : class, IInputData
        where TJob : struct, IJobBase
    {
        private const String TestNamePrefix = "TestRunner";

        protected readonly TDataContainer DataContainer;
        protected TJob Job;

        protected JobWrapperBase(TJob job, TData data)
        {
            Job = job;
            DataContainer = GetDataContainer(data);
        }

        private TDataContainer GetDataContainer(TData data)
        {
            return InitDataContainer(data);
        }

        protected abstract TDataContainer InitDataContainer(TData data);

        public void Run(Allocator allocator, bool scheduled)
        {
            InitData(allocator);
            InitJob();
            BeginTracking();
            TestCase(scheduled);
            EndTracking();
            CleanUpJob();
            CleanUpData();
        }

        private void InitData(Allocator allocator)
        {
            DataContainer.Init(allocator);
        }

        private void CleanUpData()
        {
            DataContainer.Dispose();
        }

        protected virtual void InitJob()
        {
            Job.Init();
        }

        protected virtual void CleanUpJob()
        {
            Job.Dispose();
        }

        protected abstract void TestCase(bool scheduled);

        private void BeginTracking()
        {
            Profiler.BeginSample(TestNamePrefix + ": " + Job);
        }

        private void EndTracking()
        {
            Profiler.EndSample();
        }

        public void Dispose()
        {
            CleanUpData();
            CleanUpJob();
        }
    }
}