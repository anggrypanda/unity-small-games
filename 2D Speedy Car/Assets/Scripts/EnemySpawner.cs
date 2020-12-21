using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float min_X = -2.4f, max_X = 2.4f;
    public float delayTimer = 5.0f;
    private float timer;
    public bool updateOn;

    void Start()
    {
        updateOn = false;
        StartCoroutine(Waiter());
    }

    void Update()
    {
        if (updateOn)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Vector3 temp = transform.position;
                temp.x = Random.Range(min_X, max_X);

                int rand = Random.Range(0, enemies.Length);
                Instantiate(enemies[rand], temp, enemies[rand].transform.rotation);

                timer = delayTimer;
            }
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3.2f);
        updateOn = true;
    }
}
