using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHand : MonoBehaviour {
    public Vector3 Position => transform.position;

    // 중심점
    public Vector2 Origin {
        get {
            return transform.localPosition;
        }
        set {
            transform.localPosition = value;
        }
    }

    // 마우스 따라다니는 상태에서 회전할 수 있도록 하는 변수
    [System.NonSerialized]
    public float plusAngle;

    // 손이 기본적으로 위치해 있을 각도
    [System.NonSerialized]
    public float defaultAngle;

    // 마우스와 손 사이 각도
    [System.NonSerialized]
    public float angle;

    // 마우스 손 사이 각 + 기본 손 각도
    public float Angle {
        get {
            return angle + Mathf.Sign(transform.localScale.x) * defaultAngle;
        }
    }

    public void Rotate(float angle, int direction) {
        this.angle = angle;

        var scale = transform.localScale;

        scale.x = direction * Mathf.Abs(scale.x);
        scale.y = direction * Mathf.Abs(scale.y);

        transform.localScale = scale;

        transform.localRotation = Quaternion.Euler(0, 0, direction * angle + plusAngle + defaultAngle);
    }

    // 회전, 스케일 값 초기화 함수
    public void Reset() {
        plusAngle = 0;
        transform.localRotation = Quaternion.identity;
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }

    public Tween RotatePlusAngle(float angle, float duration) {
        return DOTween.To(() => plusAngle, x => plusAngle = x, angle, duration);
    }
}