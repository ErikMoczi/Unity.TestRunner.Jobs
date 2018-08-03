using System;
using System.Collections.Generic;
using TestRunner.Generator;

namespace TestRunner.Utils
{
    internal static class Dynamics
    {
        internal static void FillDataByType(Type type, string name, int index, Dictionary<string, dynamic> typedData)
        {
            switch (EnumHelper.GetEnumFromString<DataTypeName>(type.ToString()))
            {
                #region byte

                case DataTypeName.Byte:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomByte(), name, index, typedData);
                    break;
                }

                #endregion

                #region double

                case DataTypeName.Double:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomDouble(), name, index, typedData);
                    break;
                }

                #endregion

                #region long

                case DataTypeName.Long:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomLong(), name, index, typedData);
                    break;
                }

                #endregion

                #region short

                case DataTypeName.Short:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomShort(), name, index, typedData);
                    break;
                }

                #endregion

                #region int

                case DataTypeName.Int:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt(), name, index, typedData);
                    break;
                }
                case DataTypeName.Int2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt2(), name, index, typedData);
                    break;
                }
                case DataTypeName.Int3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt3(), name, index, typedData);
                    break;
                }
                case DataTypeName.Int4:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt4(), name, index, typedData);
                    break;
                }

                #endregion

                #region uint

                case DataTypeName.UInt:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt(), name, index, typedData);
                    break;
                }
                case DataTypeName.UInt2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt2(), name, index, typedData);
                    break;
                }
                case DataTypeName.UInt3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt3(), name, index, typedData);
                    break;
                }
                case DataTypeName.UInt4:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt4(), name, index, typedData);
                    break;
                }

                #endregion

                #region float

                case DataTypeName.Float:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat(), name, index, typedData);
                    break;
                }
                case DataTypeName.Float2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat2(), name, index, typedData);
                    break;
                }
                case DataTypeName.Float3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat3(), name, index, typedData);
                    break;
                }
                case DataTypeName.Float4:
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

        private static void SetDataToDynamicTypeArray<T>(T newValue, string name, int index,
            Dictionary<string, dynamic> typedData)
            where T : struct
        {
            // ReSharper disable once PossibleNullReferenceException
            (typedData[name] as T[])[index] = newValue;
        }
    }
}