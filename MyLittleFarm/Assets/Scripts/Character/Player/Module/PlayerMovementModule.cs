using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementModule : MovementModule {
    public float speed = 4;

    [System.NonSerialized]
    public int direction;

    [System.NonSerialized]
    public float angle;

    private Vector2 input;

    public override void ModuleUpdate() {
        Vector2 characterPosition = controller.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (mousePosition.x < characterPosition.x) ? -1 : 1;

        var s = controller.transform.localScale;
        s.x = direction * Mathf.Abs(s.x);
        controller.transform.localScale = s;

        input.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
    }

    public override void ModuleFixedUpdate() {
        controller.rigidbody.MovePosition(controller.rigidbody.position + speed * input * Time.deltaTime);
    }
}