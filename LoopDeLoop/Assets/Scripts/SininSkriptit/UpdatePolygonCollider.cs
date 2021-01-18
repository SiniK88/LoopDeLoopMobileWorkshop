using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePolygonCollider : MonoBehaviour
{
    PolygonCollider2D polygonCollider;
    public DrawingManager1 drawManager;

    public List<Vector2> polygonPoints = new List<Vector2>();

    void Start() {
        /*polygonPoints.Add(new Vector2(0, 0));
        polygonPoints.Add(new Vector2(2, 0));
        polygonPoints.Add(new Vector2(2, 2));
        polygonPoints.Add(new Vector2(0, 2));*/
        //polygonPoints.Add(new Vector2(3, 0.5f));


        polygonCollider = GetComponent<PolygonCollider2D>();
        //var numberOfPoints = polygonCollider.GetTotalPointCount();

        drawManager = GetComponent<DrawingManager1>();

        //polygonCollider.SetPath(0, polygonPoints);
        // this sets path of 0, points (vector2) to be what is in the list "polygonPoints. 

    }

    
    void Update()
    {

    }
}
