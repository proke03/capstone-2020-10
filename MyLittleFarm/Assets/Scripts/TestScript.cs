using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public LayerMask mask;

    public Bounds bounds;

    private float angle;

    private bool isCollision;

    public Transform temp;

    private void Update() {
        Vector2 characterPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.rotation = Quaternion.Euler(0, 0, angle);

        angle = Mathf.Atan2(mousePosition.y - characterPosition.y, mousePosition.x - characterPosition.x) * Mathf.Rad2Deg;

        var px = transform.position + Quaternion.AngleAxis(angle, Vector3.forward) * bounds.center;
        temp.position = px;

        isCollision = Physics2D.OverlapBox(px, bounds.size, angle, mask) ? true : false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = isCollision ? Color.green : Color.red;
        Gizmos.matrix = Matrix4x4.TRS((Vector2)transform.position, Quaternion.Euler(0, 0, angle), transform.lossyScale);
        Gizmos.DrawWireCube((Vector2)bounds.center, bounds.size);
    }

}