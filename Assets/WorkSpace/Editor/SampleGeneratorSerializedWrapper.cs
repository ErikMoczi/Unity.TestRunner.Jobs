using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using WorkSpace.Tests.Base;

namespace WorkSpace.Editor
{
    public sealed class SampleGeneratorSerializedWrapper
    {
        private const string KeyWordCategoryAll = "All";
        private const string KeyWordExtraCategory = "Extra";
        private const char MenuSeparator = '/';

        private readonly ReorderableList _reorderableList;
        private readonly ISampleGeneratorData _sampleGeneratorData = new SampleGeneratorData();
        private readonly GenericMenu _menuCategories;

        public SampleGeneratorSerializedWrapper(SerializedProperty property)
        {
            _reorderableList =
                GenerateReorderableList(property.FindPropertyRelative(SampleGeneratorData.TargetPropertyName));
            _menuCategories = GenerateMenuCategories();

            ParseActiveGenerators();
        }

        public float GetHeight()
        {
            return _reorderableList.GetHeight();
        }

        public void DoList(Rect position)
        {
            _reorderableList.DoList(position);
        }

        private ReorderableList GenerateReorderableList(SerializedProperty property)
        {
            return new ReorderableList(property.serializedObject, property, true, true, true, true)
            {
                drawHeaderCallback = rect =>
                {
                    var defaultColor = GUI.color;
                    EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width * 0.8f, rect.height),
                        property.displayName + ": " + property.arraySize);

                    #region AddAllButton

                    GUI.backgroundColor = Color.green;
                    if (GUI.Button(new Rect(rect.width - 20, rect.y, 20f, rect.height), new GUIContent("+", "Add all"),
                        new GUIStyle(GUI.skin.box)))
                    {
                        if (Event.current.button == 0)
                        {
                            AddValues();
                        }
                        else
                        {
                            _menuCategories.ShowAsContext();
                        }
                    }

                    #endregion

                    #region RemoveAllButton

                    GUI.backgroundColor = Color.red;
                    if (GUI.Button(new Rect(rect.width, rect.y, 20f, rect.height), new GUIContent("-", "Rremove all"),
                        new GUIStyle(GUI.skin.box)))
                    {
                        RemoveValues();
                    }

                    #endregion

                    GUI.backgroundColor = defaultColor;
                },
                drawElementCallback = (rect, index, active, focused) =>
                {
                    var value = _sampleGeneratorData.Get(property.GetArrayElementAtIndex(index).stringValue);
                    EditorGUI.LabelField(
                        rect,
                        new GUIContent(value, value),
                        EditorStyles.textField
                    );
                },
                onRemoveCallback = RemoveValue,
                onAddDropdownCallback = (rect, list) =>
                {
                    var menu = new GenericMenu();
                    foreach (var item in _sampleGeneratorData.GetUnused().OrderBy(item => item.Key))
                    {
                        menu.AddItem(new GUIContent(item.Value), false, AddValue, item.Key);
                    }

                    menu.ShowAsContext();
                }
            };
        }

        private void ParseActiveGenerators()
        {
            _sampleGeneratorData.Clear();
            for (var i = 0; i < _reorderableList.serializedProperty.arraySize; i++)
            {
                var element = _reorderableList.serializedProperty.GetArrayElementAtIndex(i).stringValue;
                if (!_sampleGeneratorData.Add(element))
                {
                    _reorderableList.serializedProperty.DeleteArrayElementAtIndex(i);
                    _reorderableList.serializedProperty.serializedObject.ApplyModifiedPropertiesWithoutUndo();
                    i--;
                }
            }
        }

        private IEnumerable<KeyValuePair<string, string>> ParseCategories(
            IEnumerable<KeyValuePair<string, string>> categories)
        {
            foreach (var category in categories)
            {
                var item = category.Value.Split(SampleGeneratorData.ValueSeparator);
                if (item.Length > 1)
                {
                    for (var counter = 0; counter < item.Length; counter++)
                    {
                        var newValue = new StringBuilder(item[0]);
                        for (var i = 1; i < item.Length - counter; i++)
                        {
                            newValue.Append(SampleGeneratorData.ValueSeparator).Append(item[i]);
                        }

                        yield return new KeyValuePair<string, string>(
                            _sampleGeneratorData.CreateKey(newValue.ToString()),
                            _sampleGeneratorData.CreateValue(
                                newValue.Append(SampleGeneratorData.ValueSeparator).Append(KeyWordCategoryAll)
                                    .ToString()
                            )
                        );
                    }
                }
                else
                {
                    yield return category;
                }
            }
        }

        private GenericMenu GenerateMenuCategories()
        {
            var menu = new GenericMenu();
            foreach (var item in ParseCategories(_sampleGeneratorData.GetCategories()).Distinct()
                .OrderBy(item => item.Key))
            {
                menu.AddItem(new GUIContent(item.Value), false, AddValueByCategory, item.Key);
            }

            menu.AddSeparator(MenuSeparator.ToString());

            foreach (var item in _sampleGeneratorData.GetCategoriesExtra().OrderBy(item => item.Key))
            {
                menu.AddItem(new GUIContent(KeyWordExtraCategory + MenuSeparator + item.Key), false,
                    AddValueByCategoryExtra, item.Value);
            }

            return menu;
        }

        private void AddValues()
        {
            foreach (var item in _sampleGeneratorData.GetUnused())
            {
                AddValue(item.Key);
            }
        }

        private void AddValueByCategory(object o)
        {
            if (!(o is string category))
            {
                throw new ArgumentNullException(nameof(category));
            }

            foreach (var item in _sampleGeneratorData.GetByCategory(category))
            {
                AddValue(item);
            }
        }

        private void AddValueByCategoryExtra(object o)
        {
            if (!(o is string[] extraCategory))
            {
                throw new ArgumentNullException(nameof(extraCategory));
            }

            foreach (var item in extraCategory)
            {
                AddValue(item);
            }
        }

        private void AddValue(object o)
        {
            if (!(o is string data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (_sampleGeneratorData.Add(data))
            {
                AddValueReorderableList(data);
                SaveActiveValues();
            }
        }

        private void RemoveValues()
        {
            for (var i = 0; i < _reorderableList.serializedProperty.arraySize; i++)
            {
                _reorderableList.index = i;
                RemoveValue(_reorderableList);
                i--;
            }
        }

        private void RemoveValue(ReorderableList reorderableList)
        {
            var element = reorderableList.serializedProperty.GetArrayElementAtIndex(reorderableList.index).stringValue;
            _sampleGeneratorData.Remove(element);
            ReorderableList.defaultBehaviours.DoRemoveButton(reorderableList);
        }

        private void AddValueReorderableList(string data)
        {
            _reorderableList.serializedProperty.arraySize++;
            var index = _reorderableList.serializedProperty.arraySize - 1;
            _reorderableList.serializedProperty.GetArrayElementAtIndex(index).stringValue = data;
        }

        private void SaveActiveValues()
        {
            _reorderableList.serializedProperty.serializedObject.ApplyModifiedProperties();
        }
    }
}