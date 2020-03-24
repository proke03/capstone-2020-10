using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using UnityEditorInternal;

[CustomEditor(typeof(ts.TilemapGroup))]
public class TilemapGroupEditor : Editor {

    public ts.TilemapGroup group;

    private ReorderableList layerList;

    private float sq2;

    private void OnEnable() {
        sq2 = Mathf.Sqrt(2);

        group = target as ts.TilemapGroup;
        /// 각 레이어 별 타일맵 로드
        group.Initialize();

        layerList = new ReorderableList(group.layers, typeof(TilemapLayer), false, true, false, false) {
            drawHeaderCallback = r => { EditorGUI.LabelField(r, "레이어"); },
            drawElementCallback = (Rect r, int index, bool isActive, bool isFocused) => {
                EditorGUI.LabelField(r, index + " " + group.layers[index].terrain_.name + ", " + group.layers[index].event_.name);
            },
        };
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        if (GUILayout.Button("타일맵 업데이트")) {
            UpdateTilemaps();
        }

        //serializedObject.Update();

        layerList.DoLayoutList();

        //serializedObject.ApplyModifiedProperties();
    }

    // 타일맵 3d화를 자동화 하는 함수
    private void UpdateTilemaps() {

        foreach (var layer in group.layers) {
            foreach (var pos in layer.terrain_.cellBounds.allPositionsWithin) {
                layer.UpdateTile(layer.terrain_, pos);
            }

            foreach (var pos in layer.event_.cellBounds.allPositionsWithin) {
                layer.UpdateTile(layer.event_, pos);
            }
        }

    }
}