using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이미 ItemBase 클래스가 있어서 임시로 이름 붙임
/// 나중에 상의해서 바꿔야 함
/// 
/// 인벤토리에 들어갈 수 있는 아이템의 기본 클래스
/// 도구, 씨앗, 설치 도구 등이 상속받아 사용할 수 있음
/// </summary>
public abstract class ItemBaseTemp : MonoBehaviour {
    public enum Type {
        Grid,       // 그리드 시스템 이용하는 아이템(곡괭이, 양동이 등)
        NonGrid,    // 그리드 시스템 이용하지 않는 아이템(무기나 낫 같은 도구)
    }

    public Type type;

    public float range; // 현재 위치 기준 반지름 범위

    public ItemData data;

    /// <summary>
    /// 들고있는 도구를 회전시키는 등의 기능을 구현하는 메소드.
    /// 기본적으론 캐릭터가 바라보는 방향으로 도구도 회전하도록 되어 있음.
    /// </summary>
    /// <param name="controller">캐릭터 객체</param>
    /// <param name="direction">캐릭터 방향</param>
    public virtual void UpdateFunction(CharacterController2D controller, int direction) {
        //transform.parent.rotation = Quaternion.Euler(0, 0, 180 * (direction == -1 ? 1 : 0));
    }

    /// <summary>
    /// 아이템이 손에 있고 사용 버튼(기본 마우스 왼쪽 버튼)을 누른 경우 실행될 메소드
    /// </summary>
    /// <param name="controller">실행한 캐릭터</param>
    /// <param name="args">기타 필요한 매개변수</param>
    /// <returns></returns>
    public abstract IEnumerator Action(CharacterController2D controller, params object[] args);

    /// <summary>
    /// 마우스와 캐릭터 사이의 거리나 특정 오브젝트만 선택하는 등의 조건 체크를 위한 메소드
    /// </summary>
    /// <returns>특정 조건에 Action을 실행시키지 않으려면 true 반환</returns>
    public virtual bool CheckGrid(CharacterController2D controller, int mouseX, int mouseY) { return false; }

    public virtual IEnumerator Animation() {
        yield return null;
    }

    /// <summary>
    /// 아이템을 마우스 따라 회전시키기 전 호출해야 하는 메소드
    /// </summary>
    protected void MouseTrackingHelper(int direction) {
        var s = transform.parent.localScale;
        s.x = direction * Mathf.Abs(s.x);
        s.y = direction * Mathf.Abs(s.y);
        transform.parent.localScale = s;
    }
}