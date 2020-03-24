using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckModule : CharacterModule {


    /// <summary>
    /// 공격 당했을 때 실행되는 메소드
    /// </summary>
    /// <param name="direction">공격 받았을 때 받는 힘의 방향</param>
    /// <param name="power">공격 받았을 때 받는 힘의 세기</param>
    public abstract void OnHit(Vector2 direction, float power);
}