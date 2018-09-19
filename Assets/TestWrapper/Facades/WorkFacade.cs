using System;
using TestWrapper.Container.Multi.Base;
using TestWrapper.Facades.Info;
using TestWrapper.Utils.Exceptions;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Facades
{
    internal abstract class WorkFacade<TWorkerWrapper, TMultiContainer> : IWorkFacade
        where TWorkerWrapper : class, IWorkerWrapper
        where TMultiContainer : class, IMultiContainer
    {
        protected TWorkerWrapper WorkerWrapper;
        protected TMultiContainer MultiContainer => _multiContainer;

        private readonly TMultiContainer _multiContainer;
        private IWorkWrapperInfo _info;

        public WorkFacade(string testName, TWorkerWrapper workerWrapper, TMultiContainer multiContainer)
        {
            WorkerWrapper = workerWrapper;
            _multiContainer = multiContainer;
            _info = new WorkWrapperInfo(testName, WorkerWrapper.Info(), _multiContainer.Info());
        }

        #region SetUp

        public void SetUp()
        {
            try
            {
                SetUpUnSafe();
                WorkerWrapper.CustomSetUp();
            }
            catch (Exception e)
            {
                throw new TestRunnerException(nameof(SetUp), Info(), e);
            }
        }

        protected virtual void SetUpUnSafe()
        {
            _multiContainer.SetUp();
        }

        #endregion

        #region Run

        public void Run()
        {
            try
            {
                WorkerWrapper.Run();
            }
            catch (Exception e)
            {
                throw new TestRunnerException(nameof(Run), Info(), e);
            }
        }

        #endregion

        #region CleanUp

        public void CleanUp()
        {
            try
            {
                WorkerWrapper.CustomCleanUp();
                CleanUpUnSafe();
            }
            catch (Exception e)
            {
                throw new TestRunnerException(nameof(CleanUp), Info(), e);
            }
        }

        protected virtual void CleanUpUnSafe()
        {
            _multiContainer.CleanUp();
        }

        #endregion

        public IWorkWrapperInfo Info()
        {
            return _info;
        }
    }
}