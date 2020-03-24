using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RayCollider2D {
    public Vector2 bottomLeftOrigin;
    public Vector2 bottomRightOrigin;
    public Vector2 topLeftOrigin;
    public Vector2 topRightOrigin;

    public const float skinWidth = 1 / 16.0f;

    const float destRaySpacing = 4 / 16.0f;

    public float verticalSpacing;
    public float horizontalSpacing;

    public int verticalCount;
    public int horizontalCount;

    public void UpdateSpacing(Bounds bounds) {
        bounds.Expand(-2 * skinWidth);

        verticalCount = Mathf.RoundToInt(bounds.size.x / destRaySpacing);
        horizontalCount = Mathf.RoundToInt(bounds.size.y / destRaySpacing);

        verticalSpacing = bounds.size.x / (verticalCount - 1);
        horizontalSpacing = bounds.size.y / (horizontalCount - 1);
    }

    public void UpdateOrigins(Bounds bounds) {
        bounds.Expand(-2 * skinWidth);

        bottomLeftOrigin = new Vector2(bounds.min.x, bounds.min.y);
        bottomRightOrigin = new Vector2(bounds.max.x, bounds.min.y);
        topLeftOrigin = new Vector2(bounds.min.x, bounds.max.y);
        topRightOrigin = new Vector2(bounds.max.x, bounds.max.y);
    }
}