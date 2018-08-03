using System;

namespace TestRunner.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class ValueBoundaryAttribute : Attribute
    {
        public float MinRange { get; }
        public float MaxRange { get; }

        public ValueBoundaryAttribute(float minRange, float maxRange)
        {
            MinRange = minRange;
            MaxRange = maxRange;
        }

        public ValueBoundaryAttribute(byte minRange, byte maxRange) : this(Convert.ToSingle(minRange),
            Convert.ToSingle(maxRange))
        {
        }

        public ValueBoundaryAttribute(double minRange, double maxRange) : this(Convert.ToSingle(minRange),
            Convert.ToSingle(maxRange))
        {
        }

        public ValueBoundaryAttribute(int minRange, int maxRange) : this(Convert.ToSingle(minRange),
            Convert.ToSingle(maxRange))
        {
        }

        public ValueBoundaryAttribute(long minRange, long maxRange) : this(Convert.ToSingle(minRange),
            Convert.ToSingle(maxRange))
        {
        }

        public ValueBoundaryAttribute(short minRange, short maxRange) : this(Convert.ToSingle(minRange),
            Convert.ToSingle(maxRange))
        {
        }
    }
}