using Unity.Mathematics;
using UnityEngine;

namespace TestCase.Terrain
{
    internal static class Utils
    {
        public static NoiseSettings DefaultNoise()
        {
            return new NoiseSettings
            {
                Frequency = 1.5f,
                Octaves = 8,
                Lacunarity = 3.5f,
                Persistence = 0.125f
            };
        }

        public static float NoiseValue(Vector2 point, NoiseSettings config)
        {
            var frequency = config.Frequency;
            var value = noise.cnoise(point * frequency);
            var amplitude = 1f;
            var range = 1f;
            for (var o = 1; o < config.Octaves; o++)
            {
                frequency *= config.Lacunarity;
                amplitude *= config.Persistence;
                range += amplitude;
                value += noise.cnoise(point * frequency) * amplitude;
            }

            return value * (1f / range);
        }
    }
}