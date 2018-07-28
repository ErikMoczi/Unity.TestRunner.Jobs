namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3, T4> : InputData<T1, T2, T3>, IInputData<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public T4[] ItemArray4 { get; }

        public InputData(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4) : base(itemArray1,
            itemArray2, itemArray3)
        {
            ItemArray4 = itemArray4;
        }
    }
}