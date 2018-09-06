using System;

namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3, T4> : InputData<T1, T2, T3>, IInputData<T1, T2, T3, T4>
    {
        public Array ItemArray4 { get; }

        public InputData(Array itemArray1, Array itemArray2, Array itemArray3, Array itemArray4) : base(itemArray1,
            itemArray2, itemArray3)
        {
            ItemArray4 = itemArray4;
        }
    }
}