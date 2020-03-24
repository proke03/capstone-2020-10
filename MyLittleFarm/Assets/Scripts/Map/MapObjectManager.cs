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

    public void SpawnObject(GameObject prefab, Vector3Int pos, float z, bool stand) {
        if (objectData.ContainsKey((pos.x, pos.y, pos.z))) {
            Debug.LogError("같은 위치에 이미 오브젝트가 있습니다.");
            return;
        }

        var obj = Instantiate(prefab, new Vector2(pos.x, pos.y) + Vector2.one * 0.5f, Quaternion.identity).GetComponent<MapObject>();
        obj.SetZPosition(z);
        obj.IsStanding = stand;
        obj.position = pos;

        objectData.Add((pos.x, pos.y, pos.z), obj);
        Debug.Log(pos);
    }

    public void DestroyObject(int x, int y, int z) {
        Destroy(objectData[(x, y, z)].gameObject);
        objectData.Remove((x, y, z));
    }
}