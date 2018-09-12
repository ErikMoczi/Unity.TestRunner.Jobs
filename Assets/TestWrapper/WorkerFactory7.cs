using System;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Container.Multi.Base;
using TestWrapper.Facades;
using TestWrapper.InputData;
using TestWrapper.Utils.Exceptions;
using TestWrapper.Utils.Factories;
using TestWrapper.Workers;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper
{
    public static class WorkerFactory<T1, T2, T3, T4, T5, T6, T7>
    {
        public static IWorkFacade Create<TWorker>(string testName, Array itemArray1, Array itemArray2, Array itemArray3,
            Array itemArray4, Array itemArray5, Array itemArray6, Array itemArray7, IWorkConfig workConfig,
            IDataConfig[] dataConfig)
            where TWorker : struct, IWorker<T1, T2, T3, T4, T5, T6, T7>
        {
            try
            {
                return WorkFacadeFactory
                    .Instantiate<IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7>, IMultiContainer<T1, T2, T3, T4, T5, T6, T7>
                        , T1, T2, T3, T4, T5, T6, T7>(
                        testName,
                        WorkerWrapperFactory<IWorkConfig>.Instantiate<TWorker, T1, T2, T3, T4, T5, T6, T7>(workConfig),
                        MultiContainerFactory<IDataConfig>
                            .Instantiate<IInputData<T1, T2, T3, T4, T5, T6, T7>, T1, T2, T3, T4, T5, T6, T7>(
                                new InputData<T1, T2, T3, T4, T5, T6, T7>(itemArray1, itemArray2, itemArray3,
                                    itemArray4, itemArray5, itemArray6, itemArray7),
                                dataConfig
                            )
                    );
            }
            catch (Exception e)
            {
                throw new ConstructorException(testName, typeof(TWorker), e);
            }
        }
    }
}