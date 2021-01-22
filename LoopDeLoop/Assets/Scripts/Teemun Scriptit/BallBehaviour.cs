using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallColour { Blue, Red, Yellow };
public class BallBehaviour : MonoBehaviour {
    Rigidbody2D ballRb;
    Renderer rend;
    Vector2 launchDir1 = new Vector2(1f, 1f); //Oikea yläviisto
    Vector2 laucnhDir2 = new Vector2(-1f, -1f); //Vasen alaviisto
    Vector2 launchDir3 = new Vector2(1f, -1f); //Oikea alaviisto
    Vector2 launchDir4 = new Vector2(-1f, 1f); //Vasen yläviisto
    Vector2 finalDir;
    public int dirSelector;
    public int colourSelector;
    public float speed;
    public float minAngle = 45f;
    public bool goingUp = true;
    public BallColour ballColour;
    public Material[] materials;

    void Start() {
        dirSelector = Random.Range(0, 4);
        colourSelector = Random.Range(0, 3);
        ballRb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();

        //Randomise launch direction per ball
        if (dirSelector == 0) {
            finalDir = launchDir1;
            } else if (dirSelector == 1) {
            finalDir = laucnhDir2;
            } else if (dirSelector == 2) {
            finalDir = launchDir3;
            } else if (dirSelector == 3) {
            finalDir = launchDir4;
            }

        // Pallon lopullinen suunta lähtiessä
        ballRb.velocity = finalDir.normalized * speed;

        // Väri randomiser
        if (colourSelector == 0) {
            ballColour = BallColour.Blue;
            if (ballColour == BallColour.Blue) {
                rend.material = materials[0];
                }
            } else if (colourSelector == 1) {
            ballColour = BallColour.Red;
            if (ballColour == BallColour.Red) {
                rend.material = materials[1];
                }
            } else if (colourSelector == 2) {
            ballColour = BallColour.Yellow;
            if (ballColour == BallColour.Yellow) {
                rend.material = materials[2];
                }
            }
        }

    void FixedUpdate() {
        goingUp = ballRb.velocity.y > 0;
        }

    void OnCollisionExit2D(Collision2D collision) {
        var rotClockwise = Quaternion.AngleAxis(-minAngle, Vector3.forward);
        //var rotClockwise2 = Quaternion.AngleAxis(-minAngle, Vector3.back);
        var rotCounterclockwise = Quaternion.AngleAxis(minAngle, Vector3.forward);

        var newVelocity = ballRb.velocity.normalized * speed;

        //Left angle fix
        if (Vector3.Angle(ballRb.velocity, Vector3.left) < minAngle) {
            Debug.Log("Bounced too horizontally to left");
            if (goingUp) {
                Debug.Log("Fix velocity to minAngle left and up");
                var newDir = rotClockwise * Vector3.left;
                newVelocity = newDir * speed;
                }

            }

        //Right angle fix
        if (Vector3.Angle(ballRb.velocity, Vector3.right) < minAngle) {
            Debug.Log("Bounced too horizontally to right");
            if (goingUp) {
                var newDir = rotCounterclockwise * Vector3.right;
                newVelocity = newDir * speed;
                }
            }

        //Speed after collisions
        ballRb.velocity = newVelocity;

        }
    }
