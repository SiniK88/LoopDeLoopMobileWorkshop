using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    Transform stuff; // Needs rigidbody attached with a collider
    Vector3 vel; // Holds the random velocity
    float switchDirection = 3;
    float currentTime = 0;
    Rigidbody rb;
    Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void SetVel() {
        if (Random.value > 0.5) {
            vel.x = 2 * 2 * Random.value;
        } else {
            vel.x = -2 * 2 * Random.value;
        }
        if (Random.value > .5) {
            vel.y = 2 * 12 * Random.value;
        } else {
            vel.y = -2 * 2 * Random.value;
        }
    }

    // Update is called once per frame
    void Update() {
        if (currentTime < switchDirection) {
            currentTime += 1 * Time.deltaTime;
        } else {
            SetVel();
            if (Random.value > .5) {
                switchDirection += Random.value;
            } else {
                switchDirection -= Random.value;
            }
                if (switchDirection < 1) {
                    switchDirection = 1 + Random.value;
                }
                currentTime = 0;
            }
        }

    private void FixedUpdate() {
        rb.velocity = vel;

        //vel = rb.velocity;
    }

}

