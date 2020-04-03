using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedItem : IN.PlaceableItem, IN.IRotatable {

    /// <summary>
    /// 나중에 아이템 데이터베이스에서 가져와야 함. 임시로 에디터에서 씨앗 프리팹 넣어주기.
    /// </summary>
    public GameObject tempSeedBase;

    protected override IEnumerator UseInGrid(CharacterController2D controller, Vector3Int selected) {

        var tilePos = new Vector3Int(selected.x, selected.y, 1);

        var layer = ts.TilemapGroup.Instance.layers[selected.z];

        /// 땅을 괭이로 간 뒤에 씨앗 심기 가능.
        if (layer.GetTerrainTile(tilePos) == TileManager.Instance.GetTile("SimpleTileset", "tileset4_20")) {

            MapObjectManager.Instance.SpawnObject(tempSeedBase, selected, selected.z + 0.01f, true);
        }

        yield return null;
    }
}