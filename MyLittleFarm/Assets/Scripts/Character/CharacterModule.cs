using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterModule : MonoBehaviour {
    public bool isEnabled = true;

    [System.NonSerialized] public CharacterController2D controller;

    public virtual void ModuleAwake() { }
    public virtual void ModuleStart() { }
    public virtual void ModuleUpdate() { }
    public virtual void ModuleFixedUpdate() { }

    protected T GetModule<T>() where T : CharacterModule {
        return controller.moduleList.Find(c => c.GetType().Equals(typeof(T))) as T;
    }
}