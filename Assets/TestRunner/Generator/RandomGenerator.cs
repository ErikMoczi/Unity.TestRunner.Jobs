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

        private static byte RandomRangeByte1()
        {
            return (byte) GenerateValue(byte.MinValue, byte.MaxValue);
        }

        private static double RandomRangeDouble1()
        {
            return GenerateValue(float.MinValue, float.MaxValue);
        }

        private static long RandomRangeLong1()
        {
            return (long) GenerateValue(long.MinValue, long.MaxValue);
        }

        private static short RandomRangeShort1()
        {
            return (short) GenerateValue(short.MinValue, short.MaxValue);
        }

        private static int RandomRangeInt1()
        {
            return (int) GenerateValue(int.MinValue, int.MaxValue);
        }

        private static uint RandomRangeUInt1()
        {
            // ReSharper disable once PossibleLossOfFraction
            return (uint) GenerateValue(uint.MinValue, uint.MaxValue / 2);
        }

        private static float RandomRangeFloat1()
        {
            return GenerateValue(float.MinValue, float.MaxValue);
        }

        #region byte

        internal static byte GetRandomByte1()
        {
            return RandomRangeByte1();
        }

        #endregion

        #region double

        internal static double GetRandomDouble1()
        {
            return RandomRangeDouble1();
        }

        internal static double2 GetRandomDouble2()
        {
            return new double2(RandomRangeDouble1(), RandomRangeDouble1());
        }

        internal static double3 GetRandomDouble3()
        {
            return new double3(RandomRangeDouble1(), RandomRangeDouble1(), RandomRangeDouble1());
        }

        internal static double4 GetRandomDouble4()
        {
            return new double4(RandomRangeDouble1(), RandomRangeDouble1(), RandomRangeDouble1(), RandomRangeDouble1());
        }

        #endregion

        #region long

        internal static long GetRandomLong1()
        {
            return RandomRangeLong1();
        }

        #endregion

        #region short

        internal static short GetRandomShort1()
        {
            return RandomRangeShort1();
        }

        #endregion

        #region int

        internal static int GetRandomInt1()
        {
            return RandomRangeInt1();
        }

        internal static int2 GetRandomInt2()
        {
            return new int2(RandomRangeInt1(), RandomRangeInt1());
        }

        internal static int3 GetRandomInt3()
        {
            return new int3(RandomRangeInt1(), RandomRangeInt1(), RandomRangeInt1());
        }

        internal static int4 GetRandomInt4()
        {
            return new int4(RandomRangeInt1(), RandomRangeInt1(), RandomRangeInt1(), RandomRangeInt1());
        }

        #endregion

        #region uint

        internal static uint GetRandomUInt1()
        {
            return RandomRangeUInt1();
        }

        internal static uint2 GetRandomUInt2()
        {
            return new uint2(RandomRangeUInt1(), RandomRangeUInt1());
        }

        internal static uint3 GetRandomUInt3()
        {
            return new uint3(RandomRangeUInt1(), RandomRangeUInt1(), RandomRangeUInt1());
        }

        internal static uint4 GetRandomUInt4()
        {
            return new uint4(RandomRangeUInt1(), RandomRangeUInt1(), RandomRangeUInt1(), RandomRangeUInt1());
        }

        #endregion

        #region float

        internal static float GetRandomFloat1()
        {
            return RandomRangeFloat1();
        }

        internal static float2 GetRandomFloat2()
        {
            return new float2(RandomRangeFloat1(), RandomRangeFloat1());
        }

        internal static float3 GetRandomFloat3()
        {
            return new float3(RandomRangeFloat1(), RandomRangeFloat1(), RandomRangeFloat1());
        }

        internal static float4 GetRandomFloat4()
        {
            return new float4(RandomRangeFloat1(), RandomRangeFloat1(), RandomRangeFloat1(), RandomRangeFloat1());
        }

        #endregion
    }
}