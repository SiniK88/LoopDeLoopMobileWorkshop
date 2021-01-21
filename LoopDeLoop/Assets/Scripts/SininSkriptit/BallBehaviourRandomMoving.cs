using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallBehaviourRandomMoving : MonoBehaviour
{
    Rigidbody2D ballRb;
    Renderer rend;
    Vector2 launchDir1 = new Vector2(1f, 1f); //Oikea yl‰viisto
    Vector2 laucnhDir2 = new Vector2(-1f, -1f); //Vasen alaviisto
    Vector2 launchDir3 = new Vector2(1f, -1f); //Oikea alaviisto
    Vector2 launchDir4 = new Vector2(-1f, 1f); //Vasen yl‰viisto
    Vector2 finalDir;
    public int dirSelector;
    public int colourSelector;
    public float speed;

    public float waitingTime = 2f;
    public float maxSpeed = 1f;
    private Vector3 movement;
    private float timeStart = 0;

    public float MaxVelocity = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
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

        // Pallon lopullinen suunta l‰htiess‰
        ballRb.velocity = finalDir.normalized * speed;

        // V‰ri randomiser
        /*if (colourSelector == 0) {
            ballColour = BallColour2.Blue;
            if (ballColour == BallColour2.Blue) {
                rend.material = materials[0];
            }
        } else if (colourSelector == 1) {
            ballColour = BallColour2.Red;
            if (ballColour == BallColour2.Red) {
                rend.material = materials[1];
            }
        } else if (colourSelector == 2) {
            ballColour = BallColour2.Yellow;
            if (ballColour == BallColour2.Yellow) {
                rend.material = materials[2];
            }
        }*/


    }

    void Update() { // Update runs once per frame
        timeStart -= Time.deltaTime; // v‰hennet‰‰n time.deltatime joka framella kunnes se on pienempi kuin 0
        if (timeStart <= 0) {
            movement = new Vector3(Random.Range(-2f, 3f), Random.Range(-2f, 3f), 0); // random Alue jolla pallo voi liikkua
            timeStart += waitingTime;  // lis‰t‰‰n waitingTime timeStart kohtaan, niin ett‰ hakee aina uuden random vector3 pisteen 2 sekunnin v‰lein
        }
    }

    void FixedUpdate() { //  FixedUpdate can run once, zero, or several times per frame. exactly in sync with the physics engine itself
        ballRb.AddForce(movement * maxSpeed); //  object will be accelerated by the force. Antaa siis ns. voimaa siihen suuntaan miss‰ "movement" piste on
        ballRb.velocity = Vector3.ClampMagnitude(  ballRb.velocity, MaxVelocity);

    }
}
