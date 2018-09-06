using System;

namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3> : InputData<T1, T2>, IInputData<T1, T2, T3>
    {
        public Array ItemArray3 { get; }

        public InputData(Array itemArray1, Array itemArray2, Array itemArray3) : base(itemArray1, itemArray2)
        {
            ItemArray3 = itemArray3;
        }
    }
}