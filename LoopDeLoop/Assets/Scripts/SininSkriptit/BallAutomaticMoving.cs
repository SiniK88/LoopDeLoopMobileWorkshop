using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAutomaticMoving : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 launchDirection;
    public float speed;
    public float minAngle = 30f;
    public bool goingUp = true;
    public Vector3 startingPosition;

    Vector3 lastVelocity; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.velocity = launchDirection.normalized * speed; // normalized flattens the vector to 1, so it doesn't go faster for example 
    }


    private void OnCollisionEnter(Collision collision) {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }


    /*void OnCollisionExit(Collision collision) {
        var rotClockwise = Quaternion.AngleAxis(-minAngle, Vector3.forward); // we rotate minAngle to 
        var rotCounterClockwise = Quaternion.AngleAxis(minAngle, Vector3.forward); // we rotate minAngle to counterclockwise 
        var newVelocity = rb.velocity.normalized * speed;

        if (Vector3.Angle(rb.velocity, Vector3.left) < minAngle) {
            print(" bounced too horizontally to the left");
            if (goingUp) {
                // quaternion represents some type of rotation
                print("fix velocity to minAngle left and up");
                var newDir = rotClockwise * Vector3.left;
                newVelocity = newDir * speed;
            } else {
                print(" velocity to left and down");
                var newDir = rotCounterClockwise * Vector3.left;
                newVelocity = newDir * speed;
            }
        }

        if (Vector3.Angle(rb.velocity, Vector3.right) < minAngle) {
            print(" bounced too horizontally to the right");
            if (goingUp) {
                print("fix velocity to minAngle right and up");
                var newDir = rotClockwise * Vector3.right;
                newVelocity = newDir * speed;
            } else {
                print(" velocity to left and down");
                var newDir = rotCounterClockwise * Vector3.right;
                newVelocity = newDir * speed;
            }
        }

        // we will reset velocity, if it loses speed in collisons
        rb.velocity = newVelocity; // we only set new velocity once at the end
    } */
    

    void FixedUpdate() {
        lastVelocity = rb.velocity;

        goingUp = rb.velocity.y > 0;

        // testing if collisions lose energy
        if (Mathf.Abs(rb.velocity.magnitude - speed) > 0.1) {
            //Debug.LogError("Speed got messed up" + rb.velocity.magnitude); 
        }
    }
}
