namespace TestWrapper.Workers
{
    public interface IWorker
    {
    }

    public interface IWorker<T1> : IWorker
    {
        int DataSize { get; set; }
        T1 Data1 { get; set; }
    }

    public interface IWorker<T1, T2> : IWorker<T1>
    {
        T2 Data2 { get; set; }
    }

    public interface IWorker<T1, T2, T3> : IWorker<T1, T2>
    {
        T3 Data3 { get; set; }
    }

    public interface IWorker<T1, T2, T3, T4> : IWorker<T1, T2, T3>
    {
        T4 Data4 { get; set; }
    }

    public interface IWorker<T1, T2, T3, T4, T5> : IWorker<T1, T2, T3, T4>
    {
        T5 Data5 { get; set; }
    }

    public interface IWorker<T1, T2, T3, T4, T5, T6> : IWorker<T1, T2, T3, T4, T5>
    {
        T6 Data6 { get; set; }
    }

    public interface IWorker<T1, T2, T3, T4, T5, T6, T7> : IWorker<T1, T2, T3, T4, T5, T6>
    {
        T7 Data7 { get; set; }
    }

    public interface IWorker<T1, T2, T3, T4, T5, T6, T7, T8> : IWorker<T1, T2, T3, T4, T5, T6, T7>
    {
        T8 Data8 { get; set; }
    }

    public interface IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IWorker<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        T9 Data9 { get; set; }
    }
}