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
                #region byte

                case InputDataTypeName.Byte1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomByte1(), name, index, typedData);
                    break;
                }

                #endregion

                #region double

                case InputDataTypeName.Double1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomDouble1(), name, index, typedData);
                    break;
                }

                case InputDataTypeName.Double2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomDouble2(), name, index, typedData);
                    break;
                }

                case InputDataTypeName.Double3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomDouble3(), name, index, typedData);
                    break;
                }

                case InputDataTypeName.Double4:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomDouble4(), name, index, typedData);
                    break;
                }

                #endregion

                #region long

                case InputDataTypeName.Long1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomLong1(), name, index, typedData);
                    break;
                }

                #endregion

                #region short

                case InputDataTypeName.Short1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomShort1(), name, index, typedData);
                    break;
                }

                #endregion

                #region int

                case InputDataTypeName.Int1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomInt1(), name, index, typedData);
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

                #region uint

                case InputDataTypeName.UInt1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt1(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.UInt2:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt2(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.UInt3:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt3(), name, index, typedData);
                    break;
                }
                case InputDataTypeName.UInt4:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomUInt4(), name, index, typedData);
                    break;
                }

                #endregion

                #region float

                case InputDataTypeName.Float1:
                {
                    SetDataToDynamicTypeArray(RandomGenerator.GetRandomFloat1(), name, index, typedData);
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

        private static void SetDataToDynamicTypeArray<T>(T newValue, string name, int index,
            Dictionary<string, dynamic> typedData)
            where T : struct
        {
            // ReSharper disable once PossibleNullReferenceException
            (typedData[name] as T[])[index] = newValue;
        }
    }
}