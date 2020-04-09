using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    * (Levi Schoof)
    * (BulletSpawner.CS)
    * (Assignment 10)
    * (Calls the Object Pooling class to instantiate bullets)
*/
public class BulletSpawner : Spawner
{
    GameObject[] listOfTurrents;

    new private void Start()
    {
        base.Start();
        listOfTurrents = GameObject.FindGameObjectsWithTag("Gun");
    }
    public override void SpawnItem()
    {
        int randNum = Random.Range(0, listOfTurrents.Length);

        objectPool.SpawnFromPool("Bullet", listOfTurrents[randNum].transform.position, listOfTurrents[randNum].transform.rotation);
    }
}
