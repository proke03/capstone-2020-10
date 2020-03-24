using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor {
    public override void OnInspectorGUI() {
        var t = target as ItemData;

        EditorGUILayout.LabelField("아이템 기본 정보", new GUIStyle("Label") { fontSize = 12, fontStyle = FontStyle.Bold });
        EditorGUILayout.Space();

        t.name = EditorGUILayout.TextField(new GUIContent("이름", "아이템 이름"), t.name);

        //EditorGUILayout.BeginHorizontal();
        t.icon = EditorGUILayout.ObjectField("아이콘", t.icon, typeof(Sprite), true) as Sprite;
        t.sprite = EditorGUILayout.ObjectField("이미지", t.sprite, typeof(Sprite), true) as Sprite;
        //EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField(new GUIContent("설명", "아이템 설명"));
        t.description = EditorGUILayout.TextArea(t.description, new GUIStyle("TextArea") { wordWrap = true, }, GUILayout.Height(EditorGUIUtility.singleLineHeight * 4));

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("아이템 사용 정보", new GUIStyle("Label") { fontSize = 12, fontStyle = FontStyle.Bold });
        EditorGUILayout.Space();

        t.speed = EditorGUILayout.FloatField(new GUIContent("사용 속도", "도구 1초당 사용 횟수(도구 휘두르는 시간 포함)"), t.speed);
        t.swingAnimationSpeed = EditorGUILayout.Slider(new GUIContent("휘두르는 속도", "도구 휘두르는 애니메이션 재생 시간"), t.swingAnimationSpeed, 0, t.speed);
        t.turbo = EditorGUILayout.Toggle(new GUIContent("연사 가능", "공격 버튼 누르고 있으면 공격이 연속으로 나감"), t.turbo);

        EditorGUILayout.Space();
    }
}