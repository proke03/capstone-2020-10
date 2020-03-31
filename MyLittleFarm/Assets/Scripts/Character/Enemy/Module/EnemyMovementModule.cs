using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementModule : MovementModule {

    [System.NonSerialized]
    public new Rigidbody2D rigidbody;

    public override void ModuleAwake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

}
