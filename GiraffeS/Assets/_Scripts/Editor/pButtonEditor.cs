using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(pButton))]
public class pButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        pButton script = (pButton)target;

        GUIContent Function = new GUIContent("On Select Function");
        script._FunctionIndex = EditorGUILayout.Popup(Function, script._FunctionIndex, script.Functions.ToArray());
    }

}
