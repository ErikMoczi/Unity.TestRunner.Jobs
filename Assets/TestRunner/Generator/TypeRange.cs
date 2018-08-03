using System.Diagnostics.CodeAnalysis;
using TestRunner.Utils.Attributes;

namespace TestRunner.Generator
{
    [SuppressMessage("ReSharper", "PossibleLossOfFraction")]
    internal enum TypeRange
    {
        [TypeName(typeof(int)), ValueBoundary(int.MinValue / 2, int.MaxValue / 2)]
        Int,

        [TypeName(typeof(float)), ValueBoundary(float.MinValue / 2, float.MaxValue / 2)]
        Float,
    }
}