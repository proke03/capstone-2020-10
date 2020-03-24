using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ToolData))]
public class ToolDataEditor : ItemDataEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var t = target as ToolData;
    }
}