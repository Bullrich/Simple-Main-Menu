/*
using UnityEngine;
using System.Collections;
using UnityEditor;
// By @JavierBullrich

namespace SimpleMainMenu
{
    [CustomEditor(typeof(SimpleMenuManager))]
	public class SimpleMenuManagerEditor : Editor {
        SimpleMenuManager manager;

        public override void OnInspectorGUI()
        {
            manager = (SimpleMenuManager)target;
            serializedObject.Update();
            var property = serializedObject.FindProperty("list");
            serializedObject.Update();
            EditorGUI.PropertyField(,property);
        }

        public SerializedProperty 
        private void OnEnable()
        {

        }

    }
}//*/