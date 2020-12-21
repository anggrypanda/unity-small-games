using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Renderer r;
    public float speed = 3.0f;
    private Vector2 offset;

    void Awake()
    {
        r = GetComponent<Renderer>();
    }

    void Update()
    {
        offset = new Vector2(0f, Time.time * speed);
        r.material.mainTextureOffset = offset;
    }
}
