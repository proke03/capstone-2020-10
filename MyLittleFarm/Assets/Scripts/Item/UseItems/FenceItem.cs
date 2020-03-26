using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceItem : IN.GridBaseItem {
    public Sprite[] fenceSprites;

    public FenceObject fencePrefab;

    public LayerMask tempMask;

    public float range = 1.5f;

    private BoxCollider2D sizeCollider;

    public override void Activated(CharacterController2D controller) {
        GameManager.Instance.itemPreview.gameObject.SetActive(true);

        // 나중에 아이템 데이터베이스 매니저 같은데서 아이템 내 사이즈 콜라이더 캐싱 해야 함
        foreach (var col in fencePrefab.GetComponentsInChildren<BoxCollider2D>()) {
            Debug.Log(col.tag);
            if (col.CompareTag("Size")) sizeCollider = col;
        }
    }

    public override void Deactivated(CharacterController2D controller) {
        GameManager.Instance.itemPreview.gameObject.SetActive(false);
    }

    public override void UpdateFunction(CharacterController2D controller, Vector2 mousePosition) {
        var gridPosition = Vector2Int.FloorToInt(mousePosition) + Vector2.one * 0.5f;
        var characterPosition = Vector2Int.FloorToInt(controller.transform.position) + Vector2.one * 0.5f;

        GameManager.Instance.itemPreview.sprite.sprite = fenceSprites[3];
        GameManager.Instance.itemPreview.transform.position = new Vector3(gridPosition.x, gridPosition.y, controller.transform.position.z);

        var len = (characterPosition - gridPosition).magnitude;

        // 모든 조건 충족 한 경우 아이템 놓기 가능
        bool condCheck = true;

        // 거리 체크
        if (len > range) condCheck = false;

        // 겹치는 오브젝트 있는지 체크
        var hit = Physics2D.OverlapBox(gridPosition + sizeCollider.offset, sizeCollider.size - Vector2.one * 0.1f, 0, tempMask);
        if (hit) condCheck = false;

        if (condCheck) { 
            GameManager.Instance.itemPreviewIndicator.color = Color.green;
        } else {
            GameManager.Instance.itemPreviewIndicator.color = Color.red;
        }
    }

    protected override IEnumerator UseInGrid(CharacterController2D controller, Vector3Int selected) {
        Vector2 gridPosition = (Vector2Int)selected + Vector2.one * 0.5f;
        var characterPosition = Vector2Int.FloorToInt(controller.transform.position) + Vector2.one * 0.5f;

        var len = (characterPosition - gridPosition).magnitude;

        if (len <= range) {
            MapObjectManager.Instance.SpawnObject(fencePrefab.gameObject, selected, selected.z, true);
        } else {

        }

        yield return null;
    }
}