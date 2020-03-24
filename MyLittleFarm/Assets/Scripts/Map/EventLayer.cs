using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// 에디터 상에서만 보이고 인게임 중에는 보이지 않아야 하는 타일맵 레이어
/// </summary>
public class EventLayer : MonoBehaviour {
    private new TilemapRenderer renderer;

    private void Awake() {
        renderer = GetComponent<TilemapRenderer>();
        renderer.enabled = false;
    }
}