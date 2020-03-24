using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTestScript : MonoBehaviour {
    private new Rigidbody2D rigidbody;

    private Vector2 input;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        input.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();
    }

    private void FixedUpdate() {
        rigidbody.MovePosition(rigidbody.position + input * Time.deltaTime * 5);
    }
}