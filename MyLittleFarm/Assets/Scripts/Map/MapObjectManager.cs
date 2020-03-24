using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectManager : MonoBehaviour {
    public static MapObjectManager Instance;

    public Dictionary<(int x, int y, int z), MapObject> objectData = new Dictionary<(int x, int y, int z), MapObject>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;

            Initialize();
        } else {
            Destroy(gameObject);
        }
    }

    private void Initialize() {
        var list = GameObject.FindObjectsOfType<MapObject>();

        foreach (var obj in list) {
            Vector3Int pos = new Vector3Int(Mathf.FloorToInt(obj.transform.position.x), Mathf.FloorToInt(obj.transform.position.y), Mathf.FloorToInt(-obj.transform.position.z));
            Debug.Log(pos);
            obj.position = pos;
            objectData.Add((pos.x, pos.y, pos.z), obj);
        }
    }

    public void DestroyObject(int x, int y, int z) {
        Destroy(objectData[(x, y, z)].gameObject);
        objectData.Remove((x, y, z));
    }
}