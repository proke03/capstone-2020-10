using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapLayer {
    public Tilemap terrain_;
    public Tilemap event_;

    public void SetTerrainTile(Vector3Int pos, TileBase tile) {
        SetTile(terrain_, pos, tile);
    }

    public CustomTile GetTerrainTile(Vector3Int pos) {
        return terrain_.GetTile<CustomTile>(pos);
    }

    public void SetEventTile(Vector3Int pos, TileBase tile) {
        SetTile(event_, pos, tile);
    }

    public CustomTile GetEventTile(Vector3Int pos) {
        return event_.GetTile<CustomTile>(pos);
    }

    public void SetTile(Tilemap target, Vector3Int pos, TileBase tile) {
        target.SetTile(pos, tile);
        UpdateTile(target, pos);
    }

    public void UpdateTile(Tilemap target, Vector3Int pos) {
        var customTile = target.GetTile<CustomTile>(pos);
        if (customTile == null) return;

        if (customTile.isWall) {

            var mat = target.GetTransformMatrix(pos);

            mat.SetTRS(Vector3.zero, Quaternion.Euler(-45, 0, 0), new Vector3(1, Definitions.SQRT_2, 1));

            target.SetTransformMatrix(pos, mat);

        } else { // 벽이 아니면 z 값에 -0.5를 더함

            var mat = target.GetTransformMatrix(pos);

            mat.SetTRS(Vector3.back * 0.5f, Quaternion.identity, Vector3.one);

            target.SetTransformMatrix(pos, mat);

        }
    }
}