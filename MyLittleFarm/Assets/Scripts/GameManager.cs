using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public GameObject rectTarget;
    public GameObject triTarget;
    public GameObject interactionIcon;

    public P3DObject itemPreview;
    public SpriteRenderer itemPreviewIndicator;

    public Cinemachine.CinemachineImpulseSource impulseSource;

    private void Awake() {
        if (Instance == null) {
            Instance = this;

            Initialize();

        } else {
            Destroy(gameObject);
        }
    }

    private void Initialize() {
        interactionIcon.SetActive(false);
        rectTarget.gameObject.SetActive(false);
        triTarget.gameObject.SetActive(false);
    }

    public void SetRectTargetPosition(Vector3 position) {
        rectTarget.transform.position = Vector2Int.FloorToInt(position) + Vector2.one * 0.5f;
    }

    public void SetTriTargetPosition(Vector3 position) {
        triTarget.transform.position = Vector2Int.FloorToInt(position) + Vector2.one * 0.5f;
    }
}