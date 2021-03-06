﻿using Unity.Jobs;

namespace TestWrapper.Workers
{
    public interface IJobParallelForExt : IJobParallelFor
    {
    }

    public interface IJobParallelForExt<T1> : IJobParallelForExt, IWorker<T1>
    {
    }

    public interface IJobParallelForExt<T1, T2> : IJobParallelForExt<T1>, IWorker<T1, T2>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3> : IJobParallelForExt<T1, T2>, IWorker<T1, T2, T3>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4> : IJobParallelForExt<T1, T2, T3>, IWorker<T1, T2, T3, T4>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4, T5> : IJobParallelForExt<T1, T2, T3, T4>,
        IWorker<T1, T2, T3, T4, T5>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4, T5, T6> : IJobParallelForExt<T1, T2, T3, T4, T5>,
        IWorker<T1, T2, T3, T4, T5, T6>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4, T5, T6, T7> : IJobParallelForExt<T1, T2, T3, T4, T5, T6>,
        IWorker<T1, T2, T3, T4, T5, T6, T7>
    {
    }

    public interface
        IJobParallelForExt<T1, T2, T3, T4, T5, T6, T7, T8> : IJobParallelForExt<T1, T2, T3, T4, T5, T6, T7>,
            IWorker<T1, T2, T3, T4, T5, T6, T7, T8>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        IJobParallelForExt<T1, T2, T3, T4, T5, T6, T7, T8>, IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
    }
}