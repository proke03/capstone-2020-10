using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MapObject {
    protected override void Destroyed() {
        Debug.Log("destroyed");
    }
}