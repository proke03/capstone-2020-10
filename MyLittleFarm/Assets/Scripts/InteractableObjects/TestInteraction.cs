using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : InteractableObject {
    public override void Interaction(CharacterController2D controller) {
        Debug.Log("test interaction");
    }
}