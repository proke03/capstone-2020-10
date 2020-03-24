using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

[CustomEditor(typeof(CustomTile))]
[CanEditMultipleObjects]
public class CustomTileEditor : Editor {
    CustomTile c;

    private void OnEnable() {
        c = target as CustomTile;
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        EditorGUILayout.ObjectField("Preview", c.sprite, typeof(Sprite), false);

        if (c.isWall) {
            c.colliderType = UnityEngine.Tilemaps.Tile.ColliderType.Grid;
        } 
    }

    [CreateTileFromPalette]
    public static TileBase CreateCustomTile(Sprite sprite) {
        var tile = ScriptableObject.CreateInstance<CustomTile>();
        tile.sprite = sprite;
        tile.name = sprite.name;
        return tile;
    }
}