using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : P3DObject {
    public int hp;

    // 중심점을 가운데로 하면 false, 바닥으로 하면 true
    public bool bottomPivot = false;

    [System.NonSerialized]
    public Vector3Int position;

    // 오브젝트가 파괴(체력 0 이하)되었을 때 실행될 함수
    protected virtual void Destroyed() { }

    public void DoDamage(int damage) {
        hp -= damage;

        if (hp <= 0) {
            Destroyed();
            MapObjectManager.Instance.DestroyObject(position.x, position.y, position.z);
        }
    }
}