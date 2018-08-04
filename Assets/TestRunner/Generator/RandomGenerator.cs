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
            } while (Mathf.Abs(value) <= 1f);

            return value;
        }

        private static byte RandomRangeByte()
        {
            return (byte) GenerateValue(byte.MinValue, byte.MaxValue);
        }

        private static double RandomRangeDouble()
        {
            return GenerateValue(float.MinValue, float.MaxValue);
        }

        private static long RandomRangeLong()
        {
            return (long) GenerateValue(long.MinValue, long.MaxValue);
        }

        private static short RandomRangeShort()
        {
            return (short) GenerateValue(short.MinValue, short.MaxValue);
        }

        private static int RandomRangeInt()
        {
            return (int) GenerateValue(int.MinValue, int.MaxValue);
        }

        private static uint RandomRangeUInt()
        {
            return (uint) GenerateValue(uint.MinValue, uint.MaxValue);
        }

        private static float RandomRangeFloat()
        {
            return GenerateValue(float.MinValue, float.MaxValue);
        }

        #region byte

        internal static byte GetRandomByte()
        {
            return RandomRangeByte();
        }

        #endregion

        #region double

        internal static double GetRandomDouble()
        {
            return RandomRangeDouble();
        }

        #endregion

        #region long

        internal static long GetRandomLong()
        {
            return RandomRangeLong();
        }

        #endregion

        #region short

        internal static short GetRandomShort()
        {
            return RandomRangeShort();
        }

        #endregion

        #region int

        internal static int GetRandomInt()
        {
            return RandomRangeInt();
        }

        internal static int2 GetRandomInt2()
        {
            return new int2(RandomRangeInt(), RandomRangeInt());
        }

        internal static int3 GetRandomInt3()
        {
            return new int3(RandomRangeInt(), RandomRangeInt(), RandomRangeInt());
        }

        internal static int4 GetRandomInt4()
        {
            return new int4(RandomRangeInt(), RandomRangeInt(), RandomRangeInt(), RandomRangeInt());
        }

        #endregion

        #region uint

        internal static uint GetRandomUInt()
        {
            return RandomRangeUInt();
        }

        internal static uint2 GetRandomUInt2()
        {
            return new uint2(RandomRangeUInt(), RandomRangeUInt());
        }

        internal static uint3 GetRandomUInt3()
        {
            return new uint3(RandomRangeUInt(), RandomRangeUInt(), RandomRangeUInt());
        }

        internal static uint4 GetRandomUInt4()
        {
            return new uint4(RandomRangeUInt(), RandomRangeUInt(), RandomRangeUInt(), RandomRangeUInt());
        }

        #endregion

        #region float

        internal static float GetRandomFloat()
        {
            return RandomRangeFloat();
        }

        internal static float2 GetRandomFloat2()
        {
            return new float2(RandomRangeFloat(), RandomRangeFloat());
        }

        internal static float3 GetRandomFloat3()
        {
            return new float3(RandomRangeFloat(), RandomRangeFloat(), RandomRangeFloat());
        }

        internal static float4 GetRandomFloat4()
        {
            return new float4(RandomRangeFloat(), RandomRangeFloat(), RandomRangeFloat(), RandomRangeFloat());
        }

        #endregion
    }
}