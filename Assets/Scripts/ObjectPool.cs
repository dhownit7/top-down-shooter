using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    void Awake()
    {
        instance = this;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            poolDictionary[tag] = new Queue<GameObject>();
        }

        GameObject obj;

        if (poolDictionary[tag].Count > 0)
        {
            obj = poolDictionary[tag].Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
        }
        else
        {
            // Pool is empty, create new
            GameObject prefab = Resources.Load<GameObject>(tag);
            obj = Instantiate(prefab, position, rotation);
        }

        return obj;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        obj.SetActive(false);

        if (!poolDictionary.ContainsKey(tag))
        {
            poolDictionary[tag] = new Queue<GameObject>();
        }

        poolDictionary[tag].Enqueue(obj);
    }
}