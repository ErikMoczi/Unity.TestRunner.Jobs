using System.Diagnostics.CodeAnalysis;
using TestRunner.Utils.Attributes;

namespace TestRunner.Generator
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    internal enum TypeRange
    {
        [TypeName(typeof(byte)), ValueBoundary(byte.MinValue, byte.MaxValue)]
        Byte,

        [TypeName(typeof(double)), ValueBoundary(double.MinValue / 1000D, double.MaxValue / 1000D)]
        Double,

        [TypeName(typeof(float)), ValueBoundary(float.MinValue / 1000f, float.MaxValue / 1000f)]
        Float,

        [TypeName(typeof(int)), ValueBoundary(int.MinValue / 100, int.MaxValue / 100)]
        Int,

        [TypeName(typeof(uint)), ValueBoundary(uint.MinValue, uint.MaxValue / 100)]
        UInt,

        [TypeName(typeof(long)), ValueBoundary(long.MinValue / 1000L, long.MaxValue / 1000L)]
        Long,

        [TypeName(typeof(short)), ValueBoundary(short.MinValue, short.MaxValue)]
        Short,
    }
}