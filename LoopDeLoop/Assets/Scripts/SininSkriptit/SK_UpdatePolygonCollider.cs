using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_UpdatePolygonCollider : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;

    public List<Vector2> polygonPoints = new List<Vector2>();

    void Start() {
        polygonPoints.Add(new Vector2(0, 0));
        polygonPoints.Add(new Vector2(1, 1));
        polygonPoints.Add(new Vector2(2, 2));
        polygonPoints.Add(new Vector2(6, 6));
        polygonPoints.Add(new Vector2(1, 7));

        polygonCollider = GetComponent<PolygonCollider2D>();
        var numberOfPoints = polygonCollider.GetTotalPointCount();


        var myPoints = polygonCollider.points;
        myPoints[0] = polygonPoints[0];
        myPoints[4] = polygonPoints[4];
        // do stuff with myPoints array
        polygonCollider.points = myPoints;

        print(" joo" + myPoints[0] + myPoints[1] + myPoints[4]); 
        /*polygonCollider.points[0] = polygonPoints[0];
        polygonCollider.points[1] = polygonPoints[1];
        polygonCollider.points[2] = polygonPoints[2];
        polygonCollider.points[3] = polygonPoints[3];
        polygonCollider.points[4] = polygonPoints[4];*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
