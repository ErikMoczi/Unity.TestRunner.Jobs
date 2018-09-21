using TestWrapper.Workers;
using UnityEngine;

namespace TestCase.Terrain.SystemParallelFor
{
    public struct AllJoinSingleForSystemParallelFor : ISystemParallelForExt<Vector3[], int[]>
    {
        private Vector3[] _vertices;
        private int[] _triangles;
        private Vector2 _offset;
        private NoiseSettings _noiseSettings;
        private float _stepSize;
        private Vector2 _point00;
        private Vector2 _point10;
        private Vector2 _point01;
        private Vector2 _point11;
        private int _size;

        public int DataSize { get; set; }

        public Vector3[] Data1
        {
            get => _vertices;
            set => _vertices = value;
        }

        public int[] Data2
        {
            get => _triangles;
            set => _triangles = value;
        }

        public void Execute(int i)
        {
            var x = i % (_size + 1);
            var z = i / (_size + 1);
            var point0 = Vector2.Lerp(_point00, _point01, z * _stepSize);
            var point1 = Vector2.Lerp(_point10, _point11, z * _stepSize);
            var point = Vector2.Lerp(point0, point1, x * _stepSize);
            var noiseValue = Utils.NoiseValue(point, _noiseSettings);
            _vertices[i] = new Vector3(x * _stepSize - 0.5f, noiseValue, z * _stepSize - 0.5f);

            if (x < _size && z < _size)
            {
                var t = 6 * (i - z);
                _triangles[t] = i;
                _triangles[t + 1] = i + _size + 1;
                _triangles[t + 2] = i + 1;
                _triangles[t + 3] = i + 1;
                _triangles[t + 4] = i + _size + 1;
                _triangles[t + 5] = i + _size + 2;
            }
        }

        public void CustomSetUp()
        {
            _vertices = new Vector3[(DataSize + 1) * (DataSize + 1)];
            _triangles = new int[DataSize * DataSize * 6];
            _offset = Vector2.one;
            _noiseSettings = Utils.DefaultNoise();
            _stepSize = 1f / DataSize;
            _point00 = new Vector2(-0.5f, -0.5f) + _offset;
            _point10 = new Vector2(0.5f, -0.5f) + _offset;
            _point01 = new Vector2(-0.5f, 0.5f) + _offset;
            _point11 = new Vector2(0.5f, 0.5f) + _offset;
            _size = DataSize;
            DataSize = (_size + 1) * (_size + 1);
        }

        public void CustomCleanUp()
        {
            _offset = default;
            _noiseSettings = default;
            _stepSize = default;
            _point00 = default;
            _point10 = default;
            _point01 = default;
            _point11 = default;
            _size = default;
        }
    }
}