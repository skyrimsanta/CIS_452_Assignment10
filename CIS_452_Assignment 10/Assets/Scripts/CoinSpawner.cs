using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    * (Levi Schoof)
    * (CoinSpawner.CS)
    * (Assignment 10)
    * (Calls the Object Pooling class to instantiate coins)
*/
public class CoinSpawner : Spawner
{
    public float radius;
    private Vector3 originPoint;

    public override void SpawnItem()
    {
        originPoint = this.gameObject.transform.position;
        originPoint.x += Random.Range(-radius, radius);
        originPoint.y += Random.Range(-radius, radius);

        Debug.Log("Spawn Item");
        objectPool.SpawnFromPool("Coin", originPoint, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnItem();
        }
    }
}
