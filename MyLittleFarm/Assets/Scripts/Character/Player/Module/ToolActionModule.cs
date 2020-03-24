//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CreativeSpore.SuperTilemapEditor;
//using DG.Tweening;

//public class ToolActionModule : CharacterModule {
//    public Transform equipment;
//    public ItemBaseTemp itemOnHand;

//    private bool actionWaitFlag = false;

//    public override void ModuleUpdate() {
//        Vector2 characterPosition = controller.transform.position;
//        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//        int direction = (mousePosition.x < characterPosition.x) ? -1 : 1;

//        //var s = equipment.localScale;
//        //s.x = direction * Mathf.Abs(s.x);
//        //s.y = direction * Mathf.Abs(s.y);
//        //equipment.localScale = s;

//        if (itemOnHand != null) {
//            itemOnHand.UpdateFunction(controller, direction);

//            int mx = TilemapUtils.GetMouseGridX(GameManager.Instance.backgroundTilemap, Camera.main);
//            int my = TilemapUtils.GetMouseGridY(GameManager.Instance.backgroundTilemap, Camera.main);

//            if (itemOnHand.CheckGrid(controller, mx, my)) return;

//            // 마우스 클릭 시 도구 쪽의 기능이 실행됨(연사 켜져있으면 getmousebutton 사용)
//            bool actionPlay = itemOnHand.data.turbo ? Input.GetMouseButton(0) : Input.GetMouseButtonUp(0);
//            if (actionPlay) {
//                if (!actionWaitFlag) {
//                    StartCoroutine(RunAction(mx, my));
//                }
//            }
//        }
//    }

//    private IEnumerator RunAction(int x, int y) {
//        // 임시 코드
//        actionWaitFlag = true;
//        yield return itemOnHand.Action(controller, x, y);
//        actionWaitFlag = false;
//    }
//}