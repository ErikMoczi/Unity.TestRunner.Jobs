namespace TestRunner.InputData
{
    internal class InputData<T1, T2> : InputData<T1>, IInputData<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        public T2[] ItemArray2 { get; }

        public InputData(ref T1[] itemArray1, ref T2[] itemArray2) : base(ref itemArray1)
        {
            ItemArray2 = itemArray2;
        }
    }
}