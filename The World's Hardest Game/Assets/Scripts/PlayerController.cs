﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.5f;

    void FixedUpdate()
    {
        Vector2 temp = transform.position;

        if (Input.GetAxis("Horizontal") > 0)
        {
            temp.x += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            temp.x -= moveSpeed * Time.deltaTime;
        }


        if (Input.GetAxis("Vertical") > 0)
        {
            temp.y += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            temp.y -= moveSpeed * Time.deltaTime;
        }

        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            GameManager.instance.PlayerDied();
        }

        if (target.tag == "Goal")
        {
            GameManager.instance.PlayerWon();
        }
    }
}