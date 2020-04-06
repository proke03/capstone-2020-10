using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public CharacterController2D player;

    public GameObject rectTarget;
    public GameObject triTarget;
    public GameObject interactionIcon;

    public P3DObject itemPreview;
    public SpriteRenderer itemPreviewIndicator;

    public Cinemachine.CinemachineImpulseSource impulseSource;

    public static PausableYieldInstruction pauseCheck = new PausableYieldInstruction();

    private bool pause = false;
    public bool IsPaused {
        get {
            return pause;
        }
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;

            Initialize();

        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameManager.Instance.PauseToggle();
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

    public void Pause() {
        pause = true;
    }

    public void Resume() {
        pause = false;
    }

    public void PauseToggle() {
        pause = !pause;
    }
}