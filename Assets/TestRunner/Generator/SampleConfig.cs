using System;
using TestRunner.Generator.Interfaces;

namespace TestRunner.Generator
{
    public sealed class SampleConfig : ISampleConfig
    {
        public Type Type { get; }
        public string[] DataNames { get; }

        public SampleConfig(Type type, params string[] dataNames)
        {
            if (!type.IsValueType && !type.IsEnum)
            {
                throw new ArgumentException($"Parameter has to be struct, instead of {type}", nameof(type));
            }

            Type = type;
            DataNames = dataNames;
        }
    }
}