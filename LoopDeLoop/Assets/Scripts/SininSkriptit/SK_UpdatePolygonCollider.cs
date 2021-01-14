using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_UpdatePolygonCollider : MonoBehaviour
{
   PolygonCollider2D polygonCollider;

    public List<Vector2> polygonPoints = new List<Vector2>();

    void Start() {
        polygonPoints.Add(new Vector2(0, 0));
        polygonPoints.Add(new Vector2(1, 1));
        polygonPoints.Add(new Vector2(2, 2));
        polygonPoints.Add(new Vector2(6, 6));
        polygonPoints.Add(new Vector2(1, 7));
        polygonPoints.Add(new Vector2(9, 9));

        polygonCollider = GetComponent<PolygonCollider2D>();
        //var numberOfPoints = polygonCollider.GetTotalPointCount();

        polygonCollider.SetPath(0, polygonPoints);
        // this sets path of 0, points (vector2) to be what is in the list "polygonPoints. 

    }

    
    void Update()
    {
        
    }
}
