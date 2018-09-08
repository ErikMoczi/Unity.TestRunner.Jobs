using System;

namespace TestWrapper.Generator.Interfaces
{
    public interface ISampleConfig
    {
        Type Type { get; }
        string[] DataNames { get; }
    }
}