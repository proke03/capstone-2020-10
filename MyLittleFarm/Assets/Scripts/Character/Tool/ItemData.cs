using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "GameData/Create ItemData", order = 0)]
public class ItemData : ScriptableObject {
    /// <summary>
    /// 아이템 이름
    /// </summary>
    public new string name;

    /// <summary>
    /// 아이템 설명
    /// </summary>
    public string description;

    /// <summary>
    /// 아이템 아이콘
    /// </summary>
    public Sprite icon;

    /// <summary>
    /// 아이템 이미지
    /// </summary>
    public Sprite sprite;

    /// <summary>
    /// 아이템 사용 속도(speed = 1: 1초에 1번 공격)
    /// </summary>
    public float speed = 1.0f;

    /// <summary>
    /// 아이템 사용 애니메이션 재생 속도 비율
    /// </summary>
    public float swingAnimationSpeed = 1.0f;

    /// <summary>
    /// 마우스 버튼 누르고 있으면 자동 사용 할지 여부
    /// </summary>
    public bool turbo = false;
}