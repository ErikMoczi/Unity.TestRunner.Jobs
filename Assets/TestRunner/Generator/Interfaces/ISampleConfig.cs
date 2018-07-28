using System;

namespace TestRunner.Generator.Interfaces
{
    public interface ISampleConfig
    {
        Type Type { get; }
        string[] DataNames { get; }
    }
}