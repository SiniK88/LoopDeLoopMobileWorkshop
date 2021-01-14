using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsOfCircle : MonoBehaviour
{
    Vector2 center = new Vector2(0,0);
    float radius = 0.5f;
    float angle = 43;
    int i = 0;

    Vector2 ballpoint = new Vector2();

    List<Vector2> ballpoints = new List<Vector2>();

    CircleCollider2D circleCollider2D;
    float positionx;
    float positiony;
    float circleRadius;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        positionx = gameObject.transform.position.x; 
        positiony = gameObject.transform.position.y;
        circleRadius = circleCollider2D.radius; 

        ballpoint = new Vector2(positionx + circleRadius * Mathf.Cos(angle * (Mathf.PI / 180)), positiony + circleRadius * Mathf.Sin(angle * (Mathf.PI / 180)));
        //print(ballpoint);

        /*for (int i = 0; i < 360; i++) {

            ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(i * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(i * (Mathf.PI / 180))));
            print(ballpoints[i]);
        }*/

       /* while( i < 360)  {

            ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(i * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(i * (Mathf.PI / 180))));
            print(ballpoints[i]);
            i = i + 10;
        }*/

        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(0 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(0 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(30 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(30 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(60 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(60 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(90 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(90 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(120 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(120 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(150 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(150 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(180 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(180 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(210 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(210 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(240 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(240 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(270 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(270 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(300 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(300 * (Mathf.PI / 180))));
        ballpoints.Add(new Vector2(positionx + circleRadius * Mathf.Cos(330 * (Mathf.PI / 180)), positionx + circleRadius * Mathf.Sin(330 * (Mathf.PI / 180))));

        for (int i = 0; i < ballpoints.Count; i++) {
            print(ballpoints[i]);
        }


    }





}
