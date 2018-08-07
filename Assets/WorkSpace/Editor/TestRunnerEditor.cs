using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using WorkSpace.Extensions;
using WorkSpace.Tests.Base;

namespace WorkSpace.Editor
{
    [CustomPropertyDrawer(typeof(TestCase))]
    public sealed class TestDrawer : PropertyDrawer
    {
        private const string SkipPrefixWorkspace = "WorkSpace.Tests";
        private const string TargetPropertyName = "Generators";
        private readonly Type _lookingClasses = typeof(ISampleGenerator);

        private bool _isInit;
        private SerializedProperty _targetProperty;
        private ReorderableList _reorderableList;

        private readonly Dictionary<string, Type> _activeGenerators = new Dictionary<string, Type>();
        private Dictionary<string, Type> _sampleGenerators;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            Init(property);
            return _reorderableList.GetHeight();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_isInit) _reorderableList.DoList(position);
        }

        private void Init(SerializedProperty property)
        {
            if (_isInit)
            {
                return;
            }

            _targetProperty = property.FindPropertyRelative(TargetPropertyName);
            _sampleGenerators = _lookingClasses.GetAllDerivedTypes().ToDictionary(type => type.FullName);
            _reorderableList = GenerateReorderableList();

            ParseActiveGenerators();

            _isInit = true;
        }

        private ReorderableList GenerateReorderableList()
        {
            return new ReorderableList(_targetProperty.serializedObject, _targetProperty, true, true, true, true)
            {
                drawHeaderCallback = rect =>
                {
                    var defaultColor = GUI.color;

                    EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width * 0.8f, rect.height),
                        _targetProperty.displayName + ": " + _reorderableList.serializedProperty.arraySize);

                    GUI.backgroundColor = Color.green;
                    if (GUI.Button(new Rect(rect.width - 20, rect.y, 20f, rect.height), new GUIContent("+", "Add all"),
                        new GUIStyle(GUI.skin.box)))
                    {
                        foreach (var missingGenerator in _sampleGenerators.Keys.Except(_activeGenerators.Keys))
                        {
                            AddValue(missingGenerator);
                        }
                    }

                    GUI.backgroundColor = Color.red;
                    if (GUI.Button(new Rect(rect.width, rect.y, 20f, rect.height), new GUIContent("-", "Rremove all"),
                        new GUIStyle(GUI.skin.box)))
                    {
                        for (var i = 0; i < _reorderableList.serializedProperty.arraySize; i++)
                        {
                            _reorderableList.index = i;
                            RemoveValue(_reorderableList);
                            i--;
                        }
                    }

                    GUI.backgroundColor = defaultColor;
                },
                drawElementCallback = (rect, index, active, focused) =>
                {
                    var generator = _sampleGenerators[_targetProperty.GetArrayElementAtIndex(index).stringValue];
                    EditorGUI.LabelField(
                        rect,
                        new GUIContent(generator.Name, generator.FullName),
                        EditorStyles.textField
                    );
                },
                onRemoveCallback = RemoveValue,
                onCanRemoveCallback = list => list.count > 1,
                onAddDropdownCallback = (rect, list) =>
                {
                    var menu = new GenericMenu();
                    foreach (var item in _sampleGenerators)
                    {
                        if (_activeGenerators.ContainsKey(item.Key))
                        {
                            continue;
                        }

                        var name = item.Key.Remove(0, SkipPrefixWorkspace.Length + 1).Replace(".", "/");
                        menu.AddItem(new GUIContent(name), false, data => AddValue((string) data), item.Key);
                    }

                    menu.ShowAsContext();
                }
            };
        }

        private void ParseActiveGenerators()
        {
            _activeGenerators.Clear();
            for (var i = 0; i < _reorderableList.serializedProperty.arraySize; i++)
            {
                var element = _reorderableList.serializedProperty.GetArrayElementAtIndex(i).stringValue;
                if (!_sampleGenerators.ContainsKey(element))
                {
                    _reorderableList.serializedProperty.DeleteArrayElementAtIndex(i);
                    _targetProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
                    i--;
                }
                else
                {
                    _activeGenerators.Add(element, _sampleGenerators[element]);
                }
            }
        }

        private void AddValue(string data)
        {
            AddValueReorderableList(data);
            _activeGenerators.Add(data, _sampleGenerators[data]);
            SaveActiveValues();
        }

        private void RemoveValue(ReorderableList reorderableList)
        {
            var element = reorderableList.serializedProperty.GetArrayElementAtIndex(reorderableList.index).stringValue;
            _activeGenerators.Remove(element);
            ReorderableList.defaultBehaviours.DoRemoveButton(reorderableList);
        }

        private void AddValueReorderableList(string data)
        {
            var index = _reorderableList.serializedProperty.arraySize;
            _reorderableList.serializedProperty.arraySize++;
            _reorderableList.index = index;
            var element = _reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            element.stringValue = data;
        }

        private void SaveActiveValues()
        {
            _targetProperty.serializedObject.ApplyModifiedProperties();
        }
    }
}