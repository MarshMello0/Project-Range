﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Pick a speed you want, find the speed in real life then times by 4")]
    public float speed;
    public Vector3 initialVelocity = new Vector3(1, 0, 0);
    public Vector3  gravity = new Vector3(0,-9.8f,0);
    public Vector3 currentVelocity;
    public float bulletLife = 5;
    public float startTime;
    public Vector3 velocity;

    private void Start()
    {
        startTime = Time.time;
        initialVelocity = transform.forward * speed;
    }
    private void Update()
    {
        initialVelocity += gravity * Time.deltaTime;
        transform.position += (initialVelocity + 0.5f * gravity * Time.deltaTime) * Time.deltaTime;
        transform.up = initialVelocity;
        if (Time.time - startTime > bulletLife)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("Hit: " + collision.transform.name + ". In: " + (Time.time - startTime));
        Destroy(gameObject);
    }
}
