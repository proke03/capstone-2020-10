using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovementModule : MovementModule {

    [System.NonSerialized]
    public new Rigidbody2D rigidbody;

    [System.NonSerialized]
    public new BoxCollider2D collider;

    public override void ModuleAwake() {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponentsInChildren<BoxCollider2D>().Where(x => x.CompareTag("MainCollider")).SingleOrDefault();

        Physics2D.IgnoreCollision(GameManager.Instance.player.collider, collider);
    }

}
