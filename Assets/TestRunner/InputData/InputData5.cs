using System;

namespace TestRunner.InputData
{
    internal class InputData<T1, T2, T3, T4, T5> : InputData<T1, T2, T3, T4>, IInputData<T1, T2, T3, T4, T5>
    {
        public Array ItemArray5 { get; }

        public InputData(Array itemArray1, Array itemArray2, Array itemArray3, Array itemArray4, Array itemArray5) :
            base(itemArray1, itemArray2, itemArray3, itemArray4)
        {
            ItemArray5 = itemArray5;
        }
    }
}