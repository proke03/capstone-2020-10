using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public bool shouldExpand;
    }

    public static ObjectPooler Instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        Instance = GetComponent<ObjectPooler>();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, this.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Transform parent)
    {
        GameObject objectToSpawn = SpawnFromPool(tag, Vector3.zero, Quaternion.identity);
        objectToSpawn.transform.localScale = Vector3.one;

        objectToSpawn.transform.parent = parent;
        return objectToSpawn;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        GameObject objectToSpawn = null;

        if (poolDictionary[tag].Count > 0)
        {
            objectToSpawn = poolDictionary[tag].Dequeue();
        }
        else if (findByTag(tag).shouldExpand)
        {
            objectToSpawn = Instantiate(findByTag(tag).prefab, this.transform);
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        return objectToSpawn;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject objectToSpawn = SpawnFromPool(tag, position, rotation);

        objectToSpawn.transform.parent = parent;
        return objectToSpawn;
    }

    public void Despawn(string tag, GameObject _gameObject)
    {
        //_gameObject.GetComponent<IPooledObject>().OnObjectDespawn();
        _gameObject.SetActive(false);
        poolDictionary[tag].Enqueue(_gameObject);
    }

    public Pool findByTag(string _tag)
    {
        Pool pool = null;
        foreach (Pool p in pools)
        {
            if (p.tag == _tag)
            {
                pool = p;
                break;
            }
        }

        return pool;
    }
}