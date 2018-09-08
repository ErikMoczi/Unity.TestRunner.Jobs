﻿namespace TestWrapper.Generator.Interfaces
{
    public interface IInputDataContainer
    {
        T[] GetData<T>(string key) where T : struct;
    }
}