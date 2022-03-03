using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float speed = 2;

    Renderer re;

    void Start()
    {
        re = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        re.material.mainTextureOffset = offset;
    }
}
