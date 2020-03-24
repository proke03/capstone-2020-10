using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExt {
    public static Vector3 FloorToInt(Vector3 vector) {
        return new Vector3(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
    }

    public static Vector2 FloorToInt(Vector2 vector) {
        return new Vector2(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
    }
}