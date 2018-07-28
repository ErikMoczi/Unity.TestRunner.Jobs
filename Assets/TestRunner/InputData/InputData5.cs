namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3, T4, T5> : InputData<T1, T2, T3, T4>, IInputData<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        public T5[] ItemArray5 { get; }

        public InputData(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5) : base(
            itemArray1, itemArray2, itemArray3, itemArray4)
        {
            ItemArray5 = itemArray5;
        }
    }
}