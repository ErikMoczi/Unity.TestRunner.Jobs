using TestRunner.Workers.Base;

namespace TestRunner.Workers
{
    public interface INonJobExt : IWorker
    {
        void Execute();
    }

    public interface INonJobExt<T1> : INonJobExt, IWorkerSize
        where T1 : struct
    {
        T1[] Data1 { get; set; }
    }

    public interface INonJobExt<T1, T2> : INonJobExt<T1>
        where T1 : struct
        where T2 : struct
    {
        T2[] Data2 { get; set; }
    }

    public interface INonJobExt<T1, T2, T3> : INonJobExt<T1, T2>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        T3[] Data3 { get; set; }
    }

    public interface INonJobExt<T1, T2, T3, T4> : INonJobExt<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        T4[] Data4 { get; set; }
    }

    public interface INonJobExt<T1, T2, T3, T4, T5> : INonJobExt<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        T5[] Data5 { get; set; }
    }
}