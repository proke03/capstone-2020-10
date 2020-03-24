using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {
    public static bool interactionMode = false;

    public static bool GetMouseButtonDown(int button) {
        return !interactionMode && Input.GetMouseButtonDown(button);
    }

    public static bool GetInteractionButtonDown(int button) {
        return interactionMode && Input.GetMouseButtonDown(button);
    }
}