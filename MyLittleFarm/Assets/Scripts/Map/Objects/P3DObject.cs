using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// pseudo 3d object : 2.5D 오브젝트 클래스
/// 2D 오브젝트를 2.5D화 할 때 필요한 컴포넌트
/// </summary>
public class P3DObject : MonoBehaviour {

    [Range(0.0f, 8.0f)]
    public float zPosition = 0.0f;

    public int CurrentLayer => 20 + Mathf.FloorToInt(zPosition);

    /// <summary>
    /// 참이면 -45도 각도 기울인 뒤 세로로 늘려줌(세움)
    /// </summary>
    [SerializeField]
    protected bool isStanding = false;

    /// <summary>
    /// 2.5D화 할 대상
    /// </summary>
    private Transform p3dTarget;

    private BoxCollider2D[] colliders;

    [System.NonSerialized]
    public SpriteRenderer sprite;

    public bool IsStanding {
        get { return isStanding; }
        set {
            isStanding = value;
            SetPseudo3D();
        }
    }

    private void Awake() {
        P3DInitialize();
    }

    protected void P3DInitialize() {
        p3dTarget = transform.Find("P3DObject");

        colliders = transform.GetComponentsInChildren<BoxCollider2D>();

        sprite = p3dTarget.GetComponentInChildren<SpriteRenderer>();
        sprite.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        sprite.receiveShadows = true;

        SetPseudo3D();
        SetZPosition(zPosition);
    }

    public void SetPseudo3D() {
        /// x, y 스케일 값이 다르면 문제 생김
        if (IsStanding) {
            p3dTarget.localRotation = Quaternion.Euler(-45, 0, p3dTarget.localRotation.eulerAngles.z);
            p3dTarget.localScale = new Vector3(p3dTarget.localScale.x, p3dTarget.localScale.x * Definitions.SQRT_2, p3dTarget.localScale.z);
        } else {
            p3dTarget.localRotation = Quaternion.Euler(0, 0, p3dTarget.localRotation.eulerAngles.z);
            p3dTarget.localScale = new Vector3(p3dTarget.localScale.x, p3dTarget.localScale.x, p3dTarget.localScale.z);
        }
    }

    public void SetZPosition(float z) {
        zPosition = z;

        foreach (var col in colliders) {
            if (!(col.CompareTag("MainCollider") || col.CompareTag("Hitable"))) continue;
            col.gameObject.layer = CurrentLayer;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -zPosition - 0.5f);
    }


}