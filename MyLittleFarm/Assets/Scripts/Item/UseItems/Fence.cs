using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : IN.GridBaseItem {
    public Sprite[] fenceSprites;

    public float range = 1.5f;

    public override void Activated(CharacterController2D controller) {
        GameManager.Instance.itemPreview.gameObject.SetActive(true);
    }

    public override void Deactivated(CharacterController2D controller) {
        GameManager.Instance.itemPreview.gameObject.SetActive(false);
    }

    public override void UpdateFunction(CharacterController2D controller, Vector2 mousePosition) {
        var gridPosition = Vector2Int.FloorToInt(mousePosition) + Vector2.one * 0.5f;

        var len = ((Vector2)controller.transform.position - gridPosition).magnitude;

        GameManager.Instance.itemPreview.sprite.sprite = fenceSprites[3];

        GameManager.Instance.itemPreview.transform.position = new Vector3(gridPosition.x, gridPosition.y, controller.transform.position.z);

        if (len <= range) {
            GameManager.Instance.itemPreviewIndicator.color = Color.green;
        } else {
            GameManager.Instance.itemPreviewIndicator.color = Color.red;
        }
    }

    protected override IEnumerator UseInGrid(CharacterController2D controller, Vector3Int selected) {
        yield return null;
    }
}