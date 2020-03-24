using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "GameData/Create WeaponData", order = 2)]
public class WeaponData : ToolData {
    /// <summary>
    /// 무기 데미지
    /// </summary>
    public float damage;

    /// <summary>
    /// 무기 넉백 정도
    /// </summary>
    public float knockback;

    /// <summary>
    /// 피격 틱 간격
    /// </summary>
    public float hitCheckInterval;

    /// <summary>
    /// 공격 시 피격 되는 인원수(광역 공격 비율)
    /// </summary>
    public int hitableCount = 1;
}