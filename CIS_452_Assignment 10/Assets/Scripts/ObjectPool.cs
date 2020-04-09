using System.Collections.Generic;
using UnityEngine;
/*
    * (Levi Schoof)
    * (ObjectPool.CS)
    * (Assignment 10)
    * (Handles the Adding to and removing from the Object Pool Queues)
*/
public class ObjectPool : MonoBehaviour
{
    #region Pool Class
 /*
    * (Levi Schoof)
    * (Pool.CS)
    * (Assignment 10)
    * (The Object Pools)
*/
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    #region Singleton

    public static ObjectPool instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        FillPools();
    }

    private void FillPools()
    {
        foreach (Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < p.size; i++)
            { 
                GameObject temp = Instantiate(p.prefab);
                temp.SetActive(false);
                objectPool.Enqueue(temp);
            }

            poolDictionary.Add(p.tag, objectPool);
        }
    }


    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(poolDictionary[tag].Count > 0 && poolDictionary.ContainsKey(tag))
        {
            GameObject newObject = poolDictionary[tag].Dequeue();

            Debug.Log("Spawing Object");
            newObject.SetActive(true);
            newObject.transform.position = position;
            newObject.transform.rotation = rotation;
        }
    }


    public void PickUpItem(string tag, GameObject item)
    {
        item.SetActive(false);
        poolDictionary[tag].Enqueue(item);
    }
}
