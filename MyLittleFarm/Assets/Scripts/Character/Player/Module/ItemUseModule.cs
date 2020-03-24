using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 아이템 사용을 위한 모듈
/// </summary>
public class ItemUseModule : CharacterModule {
    /// <summary>
    /// 현재 손에 있는 아이템
    /// </summary>
    public IN.Item itemOnHand;

    /// <summary>
    /// 이미 아이템 사용 중인 경우를 체크 하는 플래그
    /// </summary>
    private bool alreadyFlag = false;

    public override void ModuleUpdate() {

        if (!itemOnHand) return;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        itemOnHand.UpdateFunction(controller, mousePosition);

        /// IRotateable 인터페이스가 포함된 아이템은 회전 가능하도록 함
        if (itemOnHand is IN.IRotateable) {
            Vector2 position = controller.hand.position;

            int direction = (mousePosition.x < position.x) ? -1 : 1;

            float angle = Mathf.Atan2(mousePosition.y - position.y, mousePosition.x - position.x) * Mathf.Rad2Deg;

            var scale = controller.hand.localScale;

            scale.x = direction * Mathf.Abs(scale.x);
            scale.y = direction * Mathf.Abs(scale.y);

            controller.hand.localScale = scale;

            controller.hand.localRotation = Quaternion.Euler(0, 0, direction * angle);
        }

        /// 아이템 사용중이지 않고 마우스 왼쪽 버튼을 누른 경우 아이템 사용
        if (!alreadyFlag && InputManager.GetMouseButtonDown(0)) {
            StartCoroutine(ItemUseCoroutine(controller, mousePosition));
        }

    }

    private IEnumerator ItemUseCoroutine(CharacterController2D controller, Vector2 mousePosition) {
        alreadyFlag = true;

        yield return itemOnHand.Use(controller, mousePosition);

        alreadyFlag = false;
    }
}