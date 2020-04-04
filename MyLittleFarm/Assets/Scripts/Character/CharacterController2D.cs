using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : P3DObject {
    [System.NonSerialized]
    public List<CharacterModule> moduleList = new List<CharacterModule>();

    [System.NonSerialized]
    public new Rigidbody2D rigidbody;

    [System.NonSerialized]
    public new BoxCollider2D collider;

    /// <summary>
    /// 캐릭터가 아이템을 들고 있을 손의 부모 오브젝트
    /// </summary>
    [System.NonSerialized]
    public CharacterHand hand;

    private void Awake() {
        P3DInitialize();

        rigidbody = GetComponent<Rigidbody2D>();
        collider = transform.Find("Collider")?.GetComponent<BoxCollider2D>();
        hand = GetComponentInChildren<CharacterHand>();

        var modules = GetComponents<CharacterModule>();
        foreach (var module in modules) {
            moduleList.Add(module);
            module.controller = this;
        }

        foreach (var module in moduleList) {
            if (module.isEnabled)
                module.ModuleAwake();
        }
    }

    private void Start() {
        foreach (var module in moduleList) {
            if (module.isEnabled)
                module.ModuleStart();
        }
    }

    protected override void PausableUpdate() {
        foreach (var module in moduleList) {
            if (module.isEnabled)
                module.ModuleUpdate();
        }
    }

    protected override void PausableFixedUpdate() {
        foreach (var module in moduleList) {
            if (module.isEnabled)
                module.ModuleFixedUpdate();
        }
    }
}