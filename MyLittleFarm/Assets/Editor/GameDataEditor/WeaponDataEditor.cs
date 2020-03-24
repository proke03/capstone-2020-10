using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WeaponData))]
public class WeaponDataEditor : ToolDataEditor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var t = target as WeaponData;

        EditorGUILayout.LabelField("무기 성능 정보", new GUIStyle("Label") { fontSize = 12, fontStyle = FontStyle.Bold });
        EditorGUILayout.Space();

        t.damage = EditorGUILayout.FloatField(new GUIContent("데미지", "무기 데미지"), t.damage);
        t.knockback = EditorGUILayout.FloatField(new GUIContent("넉백", "무기 피격 시 넉백 정도"), t.knockback);
        t.hitCheckInterval = EditorGUILayout.Slider(new GUIContent("피격 간격", "무기에 맞았을 때 피격 처리하는 간격"), t.hitCheckInterval, 0.02f, t.swingAnimationSpeed);
        t.hitableCount = EditorGUILayout.IntField(new GUIContent("광역 공격 비율", "공격 시 피격 되는 인원수"), t.hitableCount);

        EditorGUILayout.Space();
    }
}