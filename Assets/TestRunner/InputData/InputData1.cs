namespace TestRunner.InputData
{
    internal class InputData<T1> : InputData, IInputData<T1>
        where T1 : struct
    {
        public T1[] ItemArray1 { get; }

        public InputData(ref T1[] itemArray1)
        {
            ItemArray1 = itemArray1;
        }
    }
}