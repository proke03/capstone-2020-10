using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PausableMonoBehaviour : MonoBehaviour {
    // pause 될 때 실행 될 함수
    protected virtual void OnPaused() { }

    // resume 될 때 실행 될 함수
    protected virtual void OnResumed() { }

    protected virtual void PausableUpdate() { }
    protected virtual void PausableFixedUpdate() { }
    //protected virtual void PausableLateUpdate() { }

    private void Update() {
        if (!GameManager.Instance.IsPaused) {
            PausableUpdate();
        }
    }

    private void FixedUpdate() {
        if (!GameManager.Instance.IsPaused) {
            PausableFixedUpdate();
        }
    }

    //private void LateUpdate() {
    //    if (!GameManager.Instance.IsPaused) {
    //        PausableLateUpdate();
    //    }
    //}
}