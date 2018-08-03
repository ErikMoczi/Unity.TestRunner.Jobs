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
    }
}