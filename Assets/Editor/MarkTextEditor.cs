using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(TextEditor))]
public class MarkTextEditor : UnityEditor.UI.TextEditor
{
    GUIStyle GUIStype;

    void Awake()
    {

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Extention", EditorStyles.boldLabel);
    }

}
