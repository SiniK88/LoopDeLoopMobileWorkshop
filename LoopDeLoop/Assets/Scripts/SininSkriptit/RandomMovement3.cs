using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement3 : MonoBehaviour
{
    public float waitingTime = 2f;
    public float maxSpeed = 1f;
    private Vector3 movement;
    private float timeStart = 0;
    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() { // Update runs once per frame
        timeStart -= Time.deltaTime; // v‰hennet‰‰n time.deltatime joka framella kunnes se on pienempi kuin 0
        if (timeStart <= 0) {
            movement = new Vector3(Random.Range(-2f, 3f), Random.Range(-2f, 3f),0); // random Alue jolla pallo voi liikkua
            timeStart += waitingTime;  // lis‰t‰‰n waitingTime timeStart kohtaan, niin ett‰ hakee aina uuden random vector3 pisteen 2 sekunnin v‰lein
        }
    }

    void FixedUpdate() { //  FixedUpdate can run once, zero, or several times per frame. exactly in sync with the physics engine itself
        rb.AddForce(movement * maxSpeed); //  object will be accelerated by the force. Antaa siis ns. voimaa siihen suuntaan miss‰ "movement" piste on
    }
}
