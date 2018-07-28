namespace TestRunner.Generator.Interfaces
{
    internal interface IInputDataContainer
    {
        T[] GetData<T>(string key) where T : struct;
    }
}