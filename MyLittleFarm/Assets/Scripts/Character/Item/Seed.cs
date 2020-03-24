//using CreativeSpore.SuperTilemapEditor;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Seed : ItemBaseTemp {
//    public override bool CheckGrid(CharacterController2D controller, int mouseX, int mouseY) {
//        // 클릭된 위치가 범위 안쪽인지 체크
//        int cx = TilemapUtils.GetGridX(GameManager.Instance.backgroundTilemap, controller.transform.position);
//        int cy = TilemapUtils.GetGridY(GameManager.Instance.backgroundTilemap, controller.transform.position);

//        var len = Mathf.Sqrt((mouseX - cx) * (mouseX - cx) + (mouseY - cy) * (mouseY - cy));
//        if (len > range) {
//            // 사거리 바깥이면 표시되고 있던 타겟 이미지 비활성화
//            GameManager.Instance.SetTargetInactive();
//            return true;
//        }

//        var tileId = new TileData(GameManager.Instance.decorationTilemap.GetTileData(mouseX, mouseY)).tileId;

//        if (GameManager.Instance.objectMap.ExistObject(mouseX, mouseY) || tileId != 22) {
//            GameManager.Instance.SetTargetInactive();
//            return true;
//        }

//        GameManager.Instance.SetTargetSpritePosition(mouseX, mouseY);

//        return false;
//    }

//    public override IEnumerator Action(CharacterController2D controller, params object[] args) {


//        yield return null;
//    }
//}