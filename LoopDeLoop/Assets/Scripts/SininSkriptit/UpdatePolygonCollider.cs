using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePolygonCollider : MonoBehaviour
{
    LineRenderer lr;
    PolygonCollider2D polygonCollider;
    // public LineDrawerTest22 drawManager;

    public List<Vector2> polygonPoints2D = new List<Vector2>();
    public List<Vector3> linePositions = new List<Vector3>();
    void Start() {
        lr = gameObject.GetComponent<LineRenderer>();
        /*polygonPoints.Add(new Vector2(0, 0));
        polygonPoints.Add(new Vector2(2, 0));
        polygonPoints.Add(new Vector2(2, 2));
        polygonPoints.Add(new Vector2(0, 2)); */
        //polygonPoints.Add(new Vector2(3, 0.5f));

        polygonCollider = GetComponent<PolygonCollider2D>();
        //var numberOfPoints = polygonCollider.GetTotalPointCount();

        //drawManager = GetComponent<LineDrawerTest22>();
        //drawManager = GetComponent<>

        //polygonCollider.SetPath(0, polygonPoints2D);
        // this sets path of 0, points (vector2) to be what is in the list "polygonPoints. 

    }

    
    void Update()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        if(lr.loop == true ) {
            print(" line renrederer loop true ");

            Vector2[] pos2 = new Vector2[lr.positionCount];
            for (int i = 0; i < lr.positionCount; i++) {
                Vector3 tempv3 = lr.GetPosition(i);
                pos2[i] = new Vector2(tempv3.x, tempv3.y);
                //print(pos2[i]);
            }

            print("alue piirretty, toivottavasti");
            polygonCollider.SetPath(0, pos2);
        }
    }
}
