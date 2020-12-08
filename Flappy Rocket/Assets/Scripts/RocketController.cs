using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private float forceAmmount = 50f, rotateAmmount = 100f;

    [SerializeField]
    private AudioClip flySound, winSound, loseSound;

    [SerializeField]
    private ParticleSystem rocketParticle, winParticle, loseParticle;

    private float transitionTime = 2f;

    private enum State {WIN, LOSE, ALIVE};
    private State playerState = State.ALIVE;

    private AudioSource audioSource;

    private Rigidbody body;



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody>();
    }



    void Start()
    {
        
    }



    void Update()
    {
        if (playerState == State.ALIVE) 
        {
            HandleRotation();
        }
    }



    void FixedUpdate()
    {
        if (playerState == State.ALIVE) 
        {
            HandleMovement();
        }
    }



    void HandleRotation() 
    {
        body.freezeRotation = true;
        float rotationThisFrame = rotateAmmount * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
    }



    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            body.AddRelativeForce(Vector3.up * forceAmmount);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(flySound);
            }
            rocketParticle.Play();
        }
        else
        {
            rocketParticle.Stop();
        }
    }



    void LevelFinished()
    {
        playerState = State.WIN;
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        winParticle.Play();

        Invoke ("LoadNextLevel", transitionTime);
    }



    void PlayerDied()
    {
        playerState = State.LOSE;
        audioSource.Stop();
        audioSource.PlayOneShot(loseSound);
        loseParticle.Play();

        Invoke ("RestartLevel", transitionTime);
    }



    void LoadNextLevel()
    {
        int currentScene_plus_nextScene = SceneManager.GetActiveScene().buildIndex;
        currentScene_plus_nextScene += 1;
        int count = SceneManager.sceneCountInBuildSettings;

        if (currentScene_plus_nextScene == count)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentScene_plus_nextScene);
        }
    }



    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    void OnCollisionEnter (Collision target)
    {
        if (playerState != State.ALIVE)
            return;
        switch (target.gameObject.tag)
        {
            case "Friendly":
                break;

            case "Finish":
                LevelFinished();
                break;

            default:
                PlayerDied();
                break;
        }
    }
}
