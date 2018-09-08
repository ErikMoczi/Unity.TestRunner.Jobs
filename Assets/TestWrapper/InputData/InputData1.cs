using System;

namespace TestWrapper.InputData
{
    internal class InputData<T1> : InputData, IInputData<T1>
    {
        public Array ItemArray1 { get; }

        public InputData(Array itemArray1)
        {
            ItemArray1 = itemArray1;
        }
    }
}