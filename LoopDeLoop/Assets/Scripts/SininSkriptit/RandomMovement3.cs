using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement3 : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 1f;
    private Vector3 movement;
    private float timeLeft;
    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            movement = new Vector3(Random.Range(-2f, 3f), Random.Range(-2f, 3f),0);
            timeLeft += accelerationTime;
        }
    }

    void FixedUpdate() {
        rb.AddForce(movement * maxSpeed);
    }
}
