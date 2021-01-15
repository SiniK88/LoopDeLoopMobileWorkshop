using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfCircle : MonoBehaviour
{
    float angle = 43;
   
    Vector2 ballpoint = new Vector2();

    List<Vector2> ballpoints = new List<Vector2>();

    CircleCollider2D circleCollider2D;
    float positionx;
    float positiony;
    float circleRadius;
    int i = 0;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        positionx = gameObject.transform.position.x; 
        positiony = gameObject.transform.position.y;
        circleRadius = circleCollider2D.radius; 

        ballpoint = new Vector2(positionx + circleRadius * Mathf.Cos(angle * (Mathf.PI / 180)), positiony + circleRadius * Mathf.Sin(angle * (Mathf.PI / 180)));
        //print(ballpoint);

        for (int i = 0; i < 6; i++) {

            ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos((i *60) * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin((i*60) * (Mathf.PI / 180))));
            print(ballpoints[i]);
        }


        /*for (int i = 0; i < ballpoints.Count; i++) {
            print(ballpoints[i]);
        }*/


    }





}
