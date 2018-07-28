using Unity.Mathematics;
using UnityEngine;

namespace TestRunner.Generator
{
    internal static class RandomGenerator
    {
        private const int MinRange = 1;
        private const int MaxRange = 1000000;

        private static int RandomRangeInt()
        {
            return Random.Range(MinRange, MaxRange);
        }

        private static float RandomRangeFloat()
        {
            return Random.Range((float) MinRange, MaxRange);
        }

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