using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector2 playerInitialPosition;
    private GameObject[] enemies;
    private GameObject player;
  

    private void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f;
    }
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindWithTag("Player");
    }

    public void PlayerWon()
    {
        player.transform.position = playerInitialPosition;
        player.GetComponent<PlayerController>().moveSpeed += 0.3f;

        foreach (GameObject e in enemies)
        {
            e.GetComponent<EnemyController>().moveSpeed += 1f;
        }
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}