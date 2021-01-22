using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrawingState { Drawing, NotDrawing }; 
public class CollisionToLines : MonoBehaviour
{
    public DrawingState drawingState; 
    public bool collisionHappened =  false;

    LineRenderer lr;
    public List<Vector3> linePositions = new List<Vector3>();
    public List<Vector2> Points2d;
    EdgeCollider2D edgeCollider2D;
    PolygonCollider2D pc;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball1") {
            drawingState = DrawingState.NotDrawing;
            print("collision to lines happened");
            lr.loop = false;
            lr.positionCount = 0;
            //edgeCollider2D.Reset();
            //lr.SetPositions(new Vector3[] { });
            edgeCollider2D.enabled = false;
            pc.enabled = false;

            Points2d.Clear();
        }
    }

    private void Start() {
        lr = GetComponent<LineRenderer>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        Points2d = new List<Vector2>();
        pc = GetComponent<PolygonCollider2D>();
    }

    
}
