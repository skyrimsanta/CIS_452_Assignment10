using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    * (Levi Schoof)
    * (Bullet.CS)
    * (Assignment 10)
    * (Handles the Behavior of the bullet projectiles)
*/
public class Bullet : MonoBehaviour
{
    float speed = 10;
    Vector3 newPos;
    BulletSpawner bulletSpawner;
    private void OnEnable()
    {
        newPos = Vector3.zero;
        bulletSpawner = FindObjectOfType<BulletSpawner>();
        StartCoroutine(ResetBullet());
    }

    private void OnDisable()
    {
        StopCoroutine(ResetBullet());
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        newPos = this.transform.position;
        newPos += transform.right * speed * Time.deltaTime;

        this.transform.position = newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bulletSpawner.objectPool.PickUpItem("Bullet", this.gameObject);
            FindObjectOfType<GameManager>().IncreaseGold(-1);
        }
    }

    IEnumerator ResetBullet()
    {
        yield return new WaitForSeconds(10);
        bulletSpawner.objectPool.PickUpItem("Bullet", this.gameObject);
    }
}
