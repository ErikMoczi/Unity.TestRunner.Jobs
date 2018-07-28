namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3> : InputData<T1, T2>, IInputData<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        public T3[] ItemArray3 { get; }

        public InputData(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3) : base(itemArray1, itemArray2)
        {
            ItemArray3 = itemArray3;
        }
    }
}