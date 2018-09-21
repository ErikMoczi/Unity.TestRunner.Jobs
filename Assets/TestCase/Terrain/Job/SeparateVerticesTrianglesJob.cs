using TestWrapper.Workers;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;

namespace TestCase.Terrain.Job
{
    [BurstCompile]
    public struct SeparateVerticesTrianglesJob : IJobExt<NativeArray<Vector3>, NativeArray<int>>
    {
        private NativeArray<Vector3> _vertices;
        private NativeArray<int> _triangles;
        private Vector2 _offset;
        private NoiseSettings _noiseSettings;
        private float _stepSize;
        private Vector2 _point00;
        private Vector2 _point10;
        private Vector2 _point01;
        private Vector2 _point11;

        public int DataSize { get; set; }

        public NativeArray<Vector3> Data1
        {
            get => _vertices;
            set => _vertices = value;
        }

        public NativeArray<int> Data2
        {
            get => _triangles;
            set => _triangles = value;
        }

        public void Execute()
        {
            for (int z = 0, v = 0; z <= DataSize; z++)
            {
                for (int x = 0; x <= DataSize; x++, v++)
                {
                    _vertices[v] = new Vector3(x * _stepSize - 0.5f, 0, z * _stepSize - 0.5f);
                }
            }

            for (int t = 0, v = 0, y = 0; y < DataSize; y++, v++)
            {
                for (int x = 0; x < DataSize; x++, v++, t += 6)
                {
                    _triangles[t] = v;
                    _triangles[t + 1] = v + DataSize + 1;
                    _triangles[t + 2] = v + 1;
                    _triangles[t + 3] = v + 1;
                    _triangles[t + 4] = v + DataSize + 1;
                    _triangles[t + 5] = v + DataSize + 2;
                }
            }

            for (int z = 0, v = 0; z <= DataSize; z++)
            {
                var point0 = Vector2.Lerp(_point00, _point01, z * _stepSize);
                var point1 = Vector2.Lerp(_point10, _point11, z * _stepSize);
                for (int x = 0; x <= DataSize; x++, v++)
                {
                    var point = Vector2.Lerp(point0, point1, x * _stepSize);
                    var noiseValue = Utils.NoiseValue(point, _noiseSettings);
                    var temp = _vertices[v];
                    temp.y = noiseValue;
                    _vertices[v] = temp;
                }
            }
        }

        public void CustomSetUp()
        {
            _vertices = new NativeArray<Vector3>((DataSize + 1) * (DataSize + 1), Allocator.Persistent);
            _triangles = new NativeArray<int>(DataSize * DataSize * 6, Allocator.Persistent);
            _offset = Vector2.one;
            _noiseSettings = Utils.DefaultNoise();
            _stepSize = 1f / DataSize;
            _point00 = new Vector2(-0.5f, -0.5f) + _offset;
            _point10 = new Vector2(0.5f, -0.5f) + _offset;
            _point01 = new Vector2(-0.5f, 0.5f) + _offset;
            _point11 = new Vector2(0.5f, 0.5f) + _offset;
        }

        public void CustomCleanUp()
        {
            _vertices.Dispose();
            _triangles.Dispose();
            _offset = default;
            _noiseSettings = default;
            _stepSize = default;
            _point00 = default;
            _point10 = default;
            _point01 = default;
            _point11 = default;
        }
    }
}