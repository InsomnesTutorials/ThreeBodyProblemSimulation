using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    [SerializeField] private Vector2 initialAcceleration = Vector2.zero;
    [SerializeField] private Vector2 initialVelocity = Vector2.zero;
    
    private Vector2 acceleration = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    
    public Vector2 getPosition => new Vector2(transform.position.x, transform.position.y);

    private void Start()
    {
        velocity = initialVelocity;
        acceleration = initialAcceleration;
    }

    public void ApplyAcceleration(Vector2 factor)
    {
        acceleration = factor;
    }
    
    private void FixedUpdate()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        transform.position += (Vector3) velocity * Time.fixedDeltaTime;

    }
}