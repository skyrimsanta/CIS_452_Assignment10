using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    * (Levi Schoof)
    * (PlayerMovement.CS)
    * (Assignment 10)
    * (Handles the Movement Of The Player)
*/
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;

    private float horizontal;
    private float vertical;

    private Vector3 newPos;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        newPos = this.transform.position;

        newPos.x += horizontal * speed * Time.deltaTime;
        newPos.y += vertical * speed * Time.deltaTime;

        this.transform.position = newPos;
    }
}
