using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : IN.GridBaseItem, IN.IRotateable {

    /// <summary>
    /// 나중에 아이템 데이터베이스에서 가져와야 함. 임시로 에디터에서 씨앗 프리팹 넣어주기.
    /// </summary>
    public P3DObject tempSeedBase;

    protected override IEnumerator UseInGrid(CharacterController2D controller, Vector3Int selected) {

        var tilePos = new Vector3Int(selected.x, selected.y, 1);

        var layer = ts.TilemapGroup.Instance.layers[selected.z];

        /// 땅을 괭이로 간 뒤에 씨앗 심기 가능.
        if (layer.GetTerrainTile(tilePos) == TileManager.Instance.GetTile("SimpleTileset", "tileset4_20")) {

            var seed = Instantiate(tempSeedBase, new Vector3(tilePos.x, tilePos.y, 0) + Vector3.one * 0.5f, Quaternion.identity);
            seed.SetZPosition(selected.z + 0.01f);
            seed.IsStanding = true;

        }

        yield return null;
    }
}