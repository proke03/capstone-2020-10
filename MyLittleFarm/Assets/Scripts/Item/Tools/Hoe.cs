using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

namespace IN {

    public class Hoe : RangeGridItem {

        protected IEnumerator Animation(CharacterController2D controller) {
            var sequence = DOTween.Sequence();

            sequence.Append(controller.hand.RotatePlusAngle(120, 0.2f));
            sequence.Append(controller.hand.RotatePlusAngle(-90, 0.1f));
            sequence.Append(controller.hand.RotatePlusAngle(0, 0.1f));

            yield return sequence.WaitForCompletion();
        }

        protected override IEnumerator UseInRangeGrid(CharacterController2D controller, Vector3Int selected) {
            yield return GameManager.pauseCheck;

            yield return Animation(controller);

            yield return GameManager.pauseCheck;
            var tilePos = new Vector3Int(selected.x, selected.y, 1);

            var layer = ts.TilemapGroup.Instance.layers[selected.z];
            if (layer.GetTerrainTile(tilePos) == null) {

                layer.SetTerrainTile(tilePos, TileManager.Instance.GetTile("SimpleTileset", "tileset4_20"));

            } else {

                layer.SetTerrainTile(tilePos, null);

            }
    

            yield return null;
        }
    }

}