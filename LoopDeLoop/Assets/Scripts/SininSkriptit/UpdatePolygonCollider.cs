using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePolygonCollider : MonoBehaviour
{
   PolygonCollider2D polygonCollider;

    public List<Vector2> polygonPoints = new List<Vector2>();

    void Start() {
        polygonPoints.Add(new Vector2(0, 1));
        polygonPoints.Add(new Vector2(-1, 1));
        polygonPoints.Add(new Vector2(-0.5f, -1));
        polygonPoints.Add(new Vector2(0.5f, -1));
        polygonPoints.Add(new Vector2(3, 0.5f));


        polygonCollider = GetComponent<PolygonCollider2D>();
        //var numberOfPoints = polygonCollider.GetTotalPointCount();

        polygonCollider.SetPath(0, polygonPoints);
        // this sets path of 0, points (vector2) to be what is in the list "polygonPoints. 

    }

    
    void Update()
    {
        
    }
}
