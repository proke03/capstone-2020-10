//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CreativeSpore.SuperTilemapEditor;
//using DG.Tweening;

//public class HoeTool : ToolBase {
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

//        if (GameManager.Instance.objectMap.ExistObject(mouseX, mouseY)) {
//            GameManager.Instance.SetTargetInactive();
//            return true;
//        }

//        GameManager.Instance.SetTargetSpritePosition(mouseX, mouseY);

//        return false;
//    }

//    public override IEnumerator Action(CharacterController2D controller, params object[] args) {
//        int targetX = (int)args[0], targetY = (int)args[1];

//        // 임시 코드
        
//        // 클릭된 위치가 범위 안쪽인지 체크
//        int cx = TilemapUtils.GetGridX(GameManager.Instance.backgroundTilemap, controller.transform.position);
//        int cy = TilemapUtils.GetGridY(GameManager.Instance.backgroundTilemap, controller.transform.position);

//        var len = Mathf.Sqrt((targetX - cx) * (targetX - cx) + (targetY - cy) * (targetY - cy));
//        if (len > range) yield break;

//        // 클릭된 타일이 행동 가능한 타일인지 체크
//        var tid = new TileData(GameManager.Instance.backgroundTilemap.GetTileData(targetX, targetY)).tileId;
//        if (tid == 21 || (tid >= 24 && tid <= 27)) yield break;

//        // 클릭된 타일에 오브젝트가 있는지 체크
//        //if (GameManager.Instance.objectMap.ExistObject(targetX, targetY);
        

//        controller.moduleList.Find(c => c.GetType().Equals(typeof(PlayerMovementModule))).isEnabled = false;

//        yield return Animation();

//        GameManager.Instance.decorationTilemap.SetTile(targetX, targetY, 22);
//        GameManager.Instance.decorationTilemap.Refresh();

//        controller.moduleList.Find(c => c.GetType().Equals(typeof(PlayerMovementModule))).isEnabled = true;
//    }

//    public override IEnumerator Animation() {
//        var sequence = DOTween.Sequence();

//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * 100, 0.2f).SetOptions(false));
//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * -90, 0.1f).SetOptions(false));
//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * 0, 0.2f).SetOptions(true));

//        yield return sequence.WaitForCompletion();
//    }
//}