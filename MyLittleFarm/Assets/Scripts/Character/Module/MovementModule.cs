using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : CharacterModule {
    public override void ModuleAwake() {
    }

    //private Vector2 tempVelocity;
    //public float smoothTime = 0;

    public override void ModuleFixedUpdate() {
        //currentVelocity = Vector2.SmoothDamp(currentVelocity, targetVelocity, ref tempVelocity, smoothTime);
        //Process(currentVelocity * Time.deltaTime);
    }
}