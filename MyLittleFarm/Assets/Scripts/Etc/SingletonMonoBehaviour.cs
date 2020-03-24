using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

    private static T instance;
    public static T Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<T>();
            }

            return instance;
        }
    }

    protected bool CheckInstance() {
        if (Instance == this) return true;
        Destroy(gameObject);
        return false;
    }

}