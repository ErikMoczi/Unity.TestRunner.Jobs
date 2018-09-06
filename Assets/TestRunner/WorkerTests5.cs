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
    public static class WorkerTests<T1, T2, T3, T4, T5>
    {
        #region TestFacade

        internal static ITestFacade TestFacadeInstance<TWorker, TWorkConfig, TDataConfig>(string testName,
            IInputData<T1, T2, T3, T4, T5> data, TWorkConfig workConfig, TDataConfig[] dataConfig)
            where TWorker : struct, IWorker<T1, T2, T3, T4, T5>
            where TWorkConfig : class, IWorkConfig
            where TDataConfig : class, IDataConfig
        {
            return new WorkerWrapper<TWorker, TWorkConfig, T1, T2, T3, T4, T5>(workConfig).WorkerWrapper(testName, data,
                dataConfig);
        }

        #endregion

        public static ITestFacade Run<TWorker>(string testName, Array itemArray1, Array itemArray2, Array itemArray3,
            Array itemArray4, Array itemArray5, IWorkConfig workConfig, IDataConfig[] dataConfig)
            where TWorker : struct, IWorker<T1, T2, T3, T4, T5>
        {
            var data = new InputData<T1, T2, T3, T4, T5>(itemArray1, itemArray2, itemArray3, itemArray4, itemArray5);
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