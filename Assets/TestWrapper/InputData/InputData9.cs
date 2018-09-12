using System;

namespace TestWrapper.InputData
{
    internal class InputData<T1, T2, T3, T4, T5, T6, T7, T8, T9> : InputData<T1, T2, T3, T4, T5, T6, T7, T8>,
        IInputData<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public Array ItemArray9 { get; }

        public InputData(Array itemArray1, Array itemArray2, Array itemArray3, Array itemArray4, Array itemArray5,
            Array itemArray6, Array itemArray7, Array itemArray8, Array itemArray9) : base(itemArray1, itemArray2,
            itemArray3, itemArray4, itemArray5, itemArray6, itemArray7, itemArray8)
        {
            ItemArray9 = itemArray9;
        }
    }
}