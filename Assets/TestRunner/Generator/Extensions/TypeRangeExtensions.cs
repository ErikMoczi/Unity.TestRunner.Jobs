using TestRunner.Utils.Attributes;
using TestRunner.Utils.Extensions;

namespace TestRunner.Generator.Extensions
{
    internal static class TypeRangeExtensions
    {
        private static ValueBoundaryAttribute GetValueRangeAttribute(this TypeRange p)
        {
            return p.GetAttribute<ValueBoundaryAttribute>();
        }

        public static float MaxRange(this TypeRange p)
        {
            return p.GetValueRangeAttribute().MaxRange;
        }

        public static float MinRange(this TypeRange p)
        {
            return p.GetValueRangeAttribute().MinRange;
        }
    }
}