namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3, T4> : InputData<T1, T2, T3>, IInputData<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public T4[] ItemArray4 { get; }

        public InputData(ref T1[] itemArray1, ref T2[] itemArray2, ref T3[] itemArray3, ref T4[] itemArray4) : base(
            ref itemArray1, ref itemArray2, ref itemArray3)
        {
            ItemArray4 = itemArray4;
        }
    }
}