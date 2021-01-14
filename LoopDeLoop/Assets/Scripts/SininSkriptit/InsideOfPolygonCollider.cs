using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideOfPolygonCollider : MonoBehaviour
{
    PolygonCollider2D pc;
    CircleCollider2D CC2D;

    Vector2 center = new Vector2(19, 19);
    float radius = 0.5f;
    float angle = 43;

    Vector2 ballpoint = new Vector2();
    List<Vector2> ballpoints = new List<Vector2>();
    List<bool> areAllPointsInside = new List<bool>();
    bool allTrue = false; 

    [SerializeField]
    private ContactFilter2D contactFilter;

    int numColliders = 10; // maximum number of result that can be returned
    void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
        CC2D = GetComponent<CircleCollider2D>();

        for (int i = 0; i < 360; i++) {

            ballpoints.Add(new Vector2(4 + radius * Mathf.Cos(i * (Mathf.PI / 180)), 4 + radius * Mathf.Sin(i * (Mathf.PI / 180))));
            print("pisteet sisällä " + ballpoints[i]);
        }



        /* CircleCollider2D[] colliders = new CircleCollider2D[numColliders];
         int colliderCount = pc.OverlapCollider(contactFilter, colliders);
         print(" ball is touching polygon collider " + colliderCount); */

        var sisällä = pc.bounds.Contains(ballpoint);
        //print(" Sisältääkö pisteen " + sisällä);

        for (int i = 0; i < 360; i++) {

            areAllPointsInside.Add(pc.bounds.Contains(ballpoints[i]));
            print(areAllPointsInside[i]); 
        }

        foreach (bool b in areAllPointsInside) {
            if (b) {
                allTrue = true;
            } else {
                allTrue = false;
                break;
            }
        }

        if (allTrue == true) {
            print("all points inside");
        }

    }

    private void OnTriggerStay2D(Collider2D collision) {
        print("OnTriggerStay detected"); 
        if (collision.tag == "Ball1") {
            CircleCollider2D[] colliders = new CircleCollider2D[numColliders];
            int colliderCount = pc.OverlapCollider(contactFilter, colliders);
            print(" ball is touching polygon collider " + colliderCount);
        }
    }
}
