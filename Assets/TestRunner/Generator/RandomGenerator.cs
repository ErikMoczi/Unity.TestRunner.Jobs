using System;
using TestRunner.Generator.Extensions;
using TestRunner.Utils;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestRunner.Generator
{
    internal static class RandomGenerator
    {
        private static float GenerateValue(float min, float max)
        {
            float value;
            do
            {
                value = Random.Range(min, max);
            } while (Mathf.Abs(value) < 1f);

            return value;
        }

        private static T GetRandom<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsValueType)
            {
                throw new ArgumentException($"The type '{typeof(T)}' is not value type.");
            }

            var typeRange = EnumHelper.GetEnumFromString<TypeRange>(typeof(T).ToString());
            return (T) Convert.ChangeType(GenerateValue(typeRange.MinRange(), typeRange.MaxRange()), typeof(T));
        }

        #region byte

        internal static byte GetRandomByte()
        {
            return GetRandom<byte>();
        }

        #endregion

        #region double

        internal static double GetRandomDouble()
        {
            return GetRandom<double>();
        }

        #endregion

        #region long

        internal static long GetRandomLong()
        {
            return GetRandom<long>();
        }

        #endregion

        #region short

        internal static short GetRandomShort()
        {
            return GetRandom<short>();
        }

        #endregion

        #region int

        internal static int GetRandomInt()
        {
            return GetRandom<int>();
        }

        internal static int2 GetRandomInt2()
        {
            return new int2(GetRandom<int>(), GetRandom<int>());
        }

        internal static int3 GetRandomInt3()
        {
            return new int3(GetRandom<int>(), GetRandom<int>(), GetRandom<int>());
        }

        internal static int4 GetRandomInt4()
        {
            return new int4(GetRandom<int>(), GetRandom<int>(), GetRandom<int>(), GetRandom<int>());
        }

        #endregion

        #region uint

        internal static uint GetRandomUInt()
        {
            return GetRandom<uint>();
        }

        internal static uint2 GetRandomUInt2()
        {
            return new uint2(GetRandom<uint>(), GetRandom<uint>());
        }

        internal static uint3 GetRandomUInt3()
        {
            return new uint3(GetRandom<uint>(), GetRandom<uint>(), GetRandom<uint>());
        }

        internal static uint4 GetRandomUInt4()
        {
            return new uint4(GetRandom<uint>(), GetRandom<uint>(), GetRandom<uint>(), GetRandom<uint>());
        }

        #endregion

        #region float

        internal static float GetRandomFloat()
        {
            return GetRandom<float>();
        }

        internal static float2 GetRandomFloat2()
        {
            return new float2(GetRandom<float>(), GetRandom<float>());
        }

        internal static float3 GetRandomFloat3()
        {
            return new float3(GetRandom<float>(), GetRandom<float>(), GetRandom<float>());
        }

        internal static float4 GetRandomFloat4()
        {
            return new float4(GetRandom<float>(), GetRandom<float>(), GetRandom<float>(), GetRandom<float>());
        }

        #endregion
    }
}