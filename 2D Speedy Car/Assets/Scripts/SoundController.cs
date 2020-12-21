using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource takeOff, acceleration;

    void Start()
    {
        Invoke("TurnOnAcceleration", 3.1f);
    }
    void TurnOnAcceleration()
    {
        takeOff.Stop();
        acceleration.Play();
    }
}
