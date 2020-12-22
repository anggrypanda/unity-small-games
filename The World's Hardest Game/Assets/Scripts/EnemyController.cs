using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 4f;

    [SerializeField]
    private bool moveLeft;

    void Update()
    {
        if (moveLeft)
        {
            Vector2 temp = transform.position;
            temp.x -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector2 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy Collider")
        {
            moveLeft = !moveLeft;
        }
    }
}
