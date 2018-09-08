using UnityEditor;
using UnityEngine;
using WorkSpace.Tests.Base;

namespace WorkSpace.Editor
{
    [CustomPropertyDrawer(typeof(TestCaseWrapper))]
    public sealed class TestCaseWrapperPropertyDrawer : PropertyDrawer
    {
        private bool _isInit;
        private SampleGeneratorSerializedWrapper _sampleGeneratorSerializedWrapper;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            Init(property);
            return _sampleGeneratorSerializedWrapper.GetHeight();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_isInit) _sampleGeneratorSerializedWrapper.DoList(position);
        }

        private void Init(SerializedProperty property)
        {
            if (_isInit)
            {
                return;
            }

            _sampleGeneratorSerializedWrapper = new SampleGeneratorSerializedWrapper(property);

            _isInit = true;
        }
    }
}