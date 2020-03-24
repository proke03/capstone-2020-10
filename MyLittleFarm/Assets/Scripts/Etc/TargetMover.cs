using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TargetMover : MonoBehaviour {
    private void Awake() {
        transform.DOLocalMoveY(0.16f, 0.5f).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }
}