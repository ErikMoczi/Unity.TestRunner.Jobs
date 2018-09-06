using System;

namespace TestRunner.InputData
{
    internal class InputData<T1, T2> : InputData<T1>, IInputData<T1, T2>
    {
        public Array ItemArray2 { get; }

        public InputData(Array itemArray1, Array itemArray2) : base(itemArray1)
        {
            ItemArray2 = itemArray2;
        }
    }
}