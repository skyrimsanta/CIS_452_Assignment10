using UnityEngine;
/*
    * (Levi Schoof)
    * (Spawner.CS)
    * (Assignment 10)
    * (The Abstract class the in game spawners will inherent from)
*/
public abstract class Spawner : MonoBehaviour
{
    public GameObject itemPrefab;

    [HideInInspector] public ObjectPool objectPool;

    public void Start() { objectPool = ObjectPool.instance; }

    public abstract void SpawnItem();
}
