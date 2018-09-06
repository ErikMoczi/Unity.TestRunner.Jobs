using System;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Extensions;
using TestRunner.Facades;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Workers.Wrappers;

namespace TestRunner
{
    public static class WorkerTests<T1>
    {
        #region TestFacade

        internal static ITestFacade TestFacadeInstance<TWorker, TWorkConfig, TDataConfig>(string testName,
            IInputData<T1> data, TWorkConfig workConfig, TDataConfig[] dataConfig)
            where TWorker : struct, IWorker<T1>
            where TWorkConfig : class, IWorkConfig
            where TDataConfig : class, IDataConfig
        {
            return new WorkerWrapper<TWorker, TWorkConfig, T1>(workConfig).WorkerWrapper(testName, data, dataConfig);
        }

        #endregion

        public static ITestFacade Run<TWorker>(string testName, Array itemArray1, IWorkConfig workConfig,
            IDataConfig[] dataConfig)
            where TWorker : struct, IWorker<T1>
        {
            var data = new InputData<T1>(itemArray1);
            try
            {
                return TestFacadeInstance<TWorker, IWorkConfig, IDataConfig>(testName, data, workConfig, dataConfig);
            }
            catch (Exception e)
            {
                throw new Exception($"Problem with constructing test of {testName} - {typeof(TWorker)}", e);
            }
        }
    }
}