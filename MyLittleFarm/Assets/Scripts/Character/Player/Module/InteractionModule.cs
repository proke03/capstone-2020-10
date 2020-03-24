using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionModule : CharacterModule {
    public LayerMask mask;

    public float range;

    // 함수 한번 호출 용 플래그 변수
    private bool flag = false;

    public override void ModuleUpdate() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var hit = Physics2D.OverlapPoint(mousePosition, mask);
        if (hit) {
            // 마우스와 캐릭터 사이 거리가 아닌 검색된 상호작용 오브젝트와 캐릭터 사이 거리를 재야 함
            //Vector2 characterPosition = VectorExt.FloorToInt((Vector2)controller.transform.position) + Vector2.one * 0.5f;
            Vector2 characterPosition = controller.transform.position;

            float length = (characterPosition - (Vector2)hit.transform.position).magnitude;

            if (length <= range) {
                if (!flag) {
                    OnInteractionBegin(hit);
                    flag = true;
                }

                if (InputManager.GetInteractionButtonDown(0)) {
                    /// 캐싱해서 최적화 해야 함
                    hit.gameObject.GetComponent<InteractableObject>()?.Interaction(controller);
                }
            } else {
                if (flag) {
                    OnInteractionEnd();
                    flag = false;
                }
            }
        } else {
            if (flag) {
                OnInteractionEnd();
                flag = false;
            }
        }
    }

    // 커서의 이전 상태 기억
    // 임시로 구현한 방식이고 현재 상호작용 오브젝트에 마우스 갖다 대고 도구 바꾸면 보이면 안되는 커서가 나오는 문제 있음.
    // 애초에 도구마다 커서 상태를 저장하도록 하는 방식으로 구현한 뒤 현재 도구의 상태를 가져오는 방식으로 구현해야 함.
    bool tempTargetVisibility = false;

    // 상호작용 가능한 상태가 될 때 호출
    void OnInteractionBegin(Collider2D hit) {
        InputManager.interactionMode = true;
        // 커서를 상호작용에 맞는 모양으로 바꿔야 함.
        GameManager.Instance.interactionIcon.SetActive(true);
        // 나중에 좀 더 안정성 있게 수정해야 함.
        GameManager.Instance.interactionIcon.transform.position = hit.transform.GetChild(0).transform.position;

        tempTargetVisibility = GameManager.Instance.rectTarget.activeSelf;
        GameManager.Instance.rectTarget.SetActive(false);
    }

    // 상호작용 불가능한 상태가 될 때 호출
    void OnInteractionEnd() {
        InputManager.interactionMode = false;
        GameManager.Instance.interactionIcon.SetActive(false);

        GameManager.Instance.rectTarget.SetActive(tempTargetVisibility);
    }
}