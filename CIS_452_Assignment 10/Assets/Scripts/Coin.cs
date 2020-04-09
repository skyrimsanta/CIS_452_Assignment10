using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    * (Levi Schoof)
    * (Coin.CS)
    * (Assignment 10)
    * (Handles the Behavior of the Coin Pickups)
*/
public class Coin : MonoBehaviour
{
    CoinSpawner coinSpawner;

    private void Start() { coinSpawner = FindObjectOfType<CoinSpawner>(); }

    private void OnEnable()
    {
        StartCoroutine(ResetCoin());
    }

    private void OnDisable()
    {
        StopCoroutine(ResetCoin());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().IncreaseGold(1);
            coinSpawner.objectPool.PickUpItem("Coin", this.gameObject);
        }
    }

    IEnumerator ResetCoin()
    {
        yield return new WaitForSeconds(10);
        coinSpawner.objectPool.PickUpItem("Coin", this.gameObject);
    }
}
