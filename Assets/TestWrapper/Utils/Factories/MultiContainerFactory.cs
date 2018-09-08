using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Container.Multi;
using TestWrapper.Container.Multi.Base;
using TestWrapper.InputData;

namespace TestWrapper.Utils.Factories
{
    internal static class MultiContainerFactory<TConfig>
        where TConfig : class, IDataConfig
    {
        public static IMultiContainer<T1> Instantiate<TData, T1>(TData data, TConfig[] config)
            where TData : class, IInputData<T1>
        {
            return new MultiContainer<TConfig, T1>(data.ItemArray1, config);
        }

        public static IMultiContainer<T1, T2> Instantiate<TData, T1, T2>(TData data, TConfig[] config)
            where TData : class, IInputData<T1, T2>
        {
            return new MultiContainer<TConfig, T1, T2>(data.ItemArray1, data.ItemArray2, config);
        }

        public static IMultiContainer<T1, T2, T3> Instantiate<TData, T1, T2, T3>(TData data, TConfig[] config)
            where TData : class, IInputData<T1, T2, T3>
        {
            return new MultiContainer<TConfig, T1, T2, T3>(data.ItemArray1, data.ItemArray2, data.ItemArray3, config);
        }

        public static IMultiContainer<T1, T2, T3, T4> Instantiate<TData, T1, T2, T3, T4>(TData data, TConfig[] config)
            where TData : class, IInputData<T1, T2, T3, T4>
        {
            return new MultiContainer<TConfig, T1, T2, T3, T4>(data.ItemArray1, data.ItemArray2, data.ItemArray3,
                data.ItemArray4, config);
        }

        public static IMultiContainer<T1, T2, T3, T4, T5> Instantiate<TData, T1, T2, T3, T4, T5>(TData data,
            TConfig[] config)
            where TData : class, IInputData<T1, T2, T3, T4, T5>
        {
            return new MultiContainer<TConfig, T1, T2, T3, T4, T5>(data.ItemArray1, data.ItemArray2, data.ItemArray3,
                data.ItemArray4, data.ItemArray5, config);
        }
    }
}