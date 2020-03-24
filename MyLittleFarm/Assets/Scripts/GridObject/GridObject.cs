using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridObject : MonoBehaviour {
    public uint hp;

    [System.NonSerialized]
    public int x, y;

    //public virtual void AfterSetup() { }
    public abstract void OnDestroyed();
    public virtual void OnDamaged(uint damage) { }

    public void Initialize(int x, int y) {
        this.x = x;
        this.y = y;

        var pos = transform.position;
        pos.z = pos.y;
        transform.position = pos;
    }

    public void Damaged(uint damage) {
        if (hp <= 0) return;

        hp -= damage;
        OnDamaged(damage);
        if (hp <= 0) {  
            hp = 0;
            OnDestroyed();
        }
    }
}