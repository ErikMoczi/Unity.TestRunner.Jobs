using System;
using System.Collections.Generic;
using TestRunner.Generator;

namespace TestRunner.Utils
{
    internal static class Dynamics
    {
        internal static void FillDataByType(Type type, string name, int index, Dictionary<string, dynamic> typedData)
        {
            switch (type.ToString())
            {
                #region int

                case InputDataTypeName.Int:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.Int2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt2(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.Int3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt3(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.Int4:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt4(), name, index, typedData);
                    break;
                }

                #endregion

                #region float

                case InputDataTypeName.Float:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.Float2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat2(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.Float3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat3(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.Float4:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat4(), name, index, typedData);
                    break;
                }

                #endregion

                default:
                {
                    throw new Exception($"Missing implementation of {type} or not allowed type.");
                }
            }
        }

        internal static void SetDataToDynamicTypeArray<T>(T newValue, string name, int index,
            Dictionary<string, dynamic> typedData)
            where T : struct
        {
            // ReSharper disable once PossibleNullReferenceException
            (typedData[name] as T[])[index] = newValue;
        }
    }
}