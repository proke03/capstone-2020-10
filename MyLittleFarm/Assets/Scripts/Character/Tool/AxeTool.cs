//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CreativeSpore.SuperTilemapEditor;
//using DG.Tweening;

//public class AxeTool : ToolBase {
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

//        if (!GameManager.Instance.objectMap.ExistObject(mouseX, mouseY)) {
//            GameManager.Instance.SetTargetInactive();
//            return true;
//        }

//        GameManager.Instance.SetTargetSpritePosition(mouseX, mouseY);

//        return false;
//    }

//    public override IEnumerator Action(CharacterController2D controller, params object[] args) {
//        int targetX = (int)args[0], targetY = (int)args[1];

//        // 임시 코드
//        if (!GameManager.Instance.objectMap.ExistObject(targetX, targetY)) yield break;

//        controller.moduleList.Find(c => c.GetType().Equals(typeof(PlayerMovementModule))).isEnabled = false;

//        yield return Animation();

//        // 클릭된 타일이 나무 오브젝트인지 체크
//        var obj = GameManager.Instance.objectMap.GetObject(targetX, targetY);
//        if (obj is ObjTree) {
//            obj.Damaged(1);
//            GameManager.Instance.impulseSource.GenerateImpulse();
//        }

//        controller.moduleList.Find(c => c.GetType().Equals(typeof(PlayerMovementModule))).isEnabled = true;
//    }

//    public override IEnumerator Animation() {
//        var sequence = DOTween.Sequence();

//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * 100, 0.12f).SetRelative());
//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * -145, 0.06f).SetRelative());
//        sequence.Append(transform.parent.DOLocalRotate(Vector3.forward * 45, 0.12f).SetRelative());

//        yield return sequence.WaitForCompletion();
//    }
//}