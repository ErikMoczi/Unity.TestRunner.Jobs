using System;

namespace TestRunner.Utils
{
    internal static class ObjectCreator
    {
        internal static Array CreateArray(Type typ, int size)
        {
            return Array.CreateInstance(typ, size);
        }
    }
}