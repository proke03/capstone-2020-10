using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

[CustomGridBrush(true, false, false, "CustomBrush")]
public class CustomEraseBrush : GridBrush {
    //public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position) {

    //    /// 최적화 필요?
    //    foreach (var target in GameObject.FindGameObjectsWithTag("Tilemap")) {
    //        if (target.activeSelf)
    //            base.Erase(gridLayout, target, position);
    //    }

    //    Undo.RecordObject(this, "");

    //}

    [MenuItem("Assets/Create/Custom Brush")]
    public static void CreateBrush() {
        string path = EditorUtility.SaveFilePanelInProject("Save Brush", "New Brush", "Asset", "Save Brush", "Assets");
        if (path == "") return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<CustomEraseBrush>(), path);
    }
}

[CustomEditor(typeof(CustomEraseBrush))]
public class CustomBrushEditor : GridBrushEditor {

    public List<(Tilemap terrain, Tilemap event_)> layers = new List<(Tilemap terrain, Tilemap event_)>();

    protected override void OnEnable() {
        base.OnEnable();

        layers.Clear();

        var grid = GameObject.FindWithTag("TilemapGroup").transform;
        foreach (Transform layer in grid.transform) {
            layers.Add((layer.GetChild(0).GetComponent<Tilemap>(), layer.GetChild(1).GetComponent<Tilemap>()));
        }
    }

    public override void OnPaintSceneGUI(GridLayout gridLayout, GameObject brushTarget, BoundsInt position, GridBrushBase.Tool tool, bool executing) {
        base.OnPaintSceneGUI(gridLayout, brushTarget, position, tool, executing);
    }

    Vector2 scrollPos;

    public override void OnInspectorGUI() {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        var oldColor = GUI.backgroundColor;

        for (int i = layers.Count - 1; i >= 0; i--) {
            GUILayout.BeginHorizontal();

            GUILayout.Label("Layer " + i.ToString());

            if (GridPaintingState.scenePaintTarget.Equals(layers[i].terrain.gameObject)) {
                GUI.backgroundColor = Color.green;
            }

            if (GUILayout.Button("Terrain")) {
                GridPaintingState.scenePaintTarget = layers[i].terrain.gameObject;
            }

            if (GridPaintingState.scenePaintTarget.Equals(layers[i].event_.gameObject)) {
                GUI.backgroundColor = Color.green;
            } else
                GUI.backgroundColor = oldColor;

            if (GUILayout.Button("Event")) {
                GridPaintingState.scenePaintTarget = layers[i].event_.gameObject;
            }

            GUI.backgroundColor = oldColor;

            GUILayout.EndHorizontal();
        }

        EditorGUILayout.EndScrollView();
    }

}