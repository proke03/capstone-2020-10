using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempItemChangeModule : CharacterModule {

    /// <summary>
    /// 나중엔 인벤토리에서 받아올 수 있도록 해야 함.
    /// </summary>
    public IN.Item[] items;

    private ItemUseModule itemUseModule;

    // 임시 코드 * 나중에 수정해야 함 *
    int prevIndex = 0;

    public override void ModuleAwake() {
        itemUseModule = GetModule<ItemUseModule>();
    }

    public override void ModuleStart() {
        itemUseModule.itemOnHand?.Activated(controller);
    }

    public override void ModuleUpdate() {
        for (int i = 0; i < items.Length; i++) {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
                foreach (var item in items) item.gameObject.SetActive(false);

                /// 회전 가능한 아이템을 빠르게 다른 아이템으로 바꿨다가 돌려놓으면 잠깐 0도로 돌아온 뒤 마우스 각도로 이동하는 버그가 있음.
                controller.hand.Reset();

                if (prevIndex >= 0) items[prevIndex].Deactivated(controller);

                items[i].gameObject.SetActive(true);
                items[i].Activated(controller);
                itemUseModule.itemOnHand = items[i];

                prevIndex = i;
            }
        }
    }
}