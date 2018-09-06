using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Multi;
using TestRunner.Container.Multi.Base;
using TestRunner.InputData;
using TestRunner.Workers.Wrappers;

namespace TestRunner.Facades
{
    internal class
        WorkFacade<TMultiContainer, TData, TWorkerWrapper, TConfig, T1, T2, T3, T4, T5> : WorkFacade<TMultiContainer,
            TData, TWorkerWrapper, TConfig, T1, T2, T3, T4>
        where TMultiContainer : class, IMultiContainer<T1, T2, T3, T4, T5>
        where TData : class, IInputData<T1, T2, T3, T4, T5>
        where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3, T4, T5>
        where TConfig : class, IDataConfig
    {
        public WorkFacade(TWorkerWrapper worker, TData data, TConfig[] config) : base(worker, data, config)
        {
        }

        protected override TMultiContainer InitMultiContainer(TData data, TConfig[] config)
        {
            return new MultiContainer<TConfig, T1, T2, T3, T4, T5>(data.ItemArray1, data.ItemArray2, data.ItemArray3,
                data.ItemArray4, data.ItemArray5, config) as TMultiContainer;
        }

        public override void Init()
        {
            base.Init();
            Worker.Data5 = MultiContainer.Item5;
        }
    }
}