using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerSolid : MonoBehaviour
{
    LineRenderer lr;
    public List<Vector3> linePositions = new List<Vector3>();
    Vector3 mousePos;
    public GameObject drawPrefab;
    public float minDistance = 0.2f;

    public bool circleDrawn = false;

    EdgeCollider2D edgeCollider2D;
    public List<Vector2> Points2d;
    CollisionToLines collisionToLines;
    PolygonCollider2D pc;
    List<Vector2> defaultPoints = new List<Vector2>() { new Vector2(6, 6), new Vector2(7, 7) };

    float waitingTime = 1f;
    float timer = 0;

    void Start() {

        lr = drawPrefab.GetComponent<LineRenderer>();
        collisionToLines = drawPrefab.GetComponent<CollisionToLines>();

        edgeCollider2D = drawPrefab.GetComponent<EdgeCollider2D>();
        Points2d = new List<Vector2>();
        pc = drawPrefab.GetComponent<PolygonCollider2D>();

        /*var drawing = Instantiate(drawPrefab);
        lr = drawing.GetComponent<LineRenderer>();
        collisionToLines = drawing.GetComponent<CollisionToLines>();

        edgeCollider2D = drawing.GetComponent<EdgeCollider2D>();
        Points2d = new List<Vector2>();
        pc = drawing.GetComponent<PolygonCollider2D>();*/
    }


    void Update() {
        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.4f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 mousepos2d = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            lr.enabled = true;
            circleDrawn = false;
            lr.loop = false;
            linePositions.Clear();
            lr.SetPositions(new Vector3[] { });

            AddPoint();
            Points2d.Clear();
            edgeCollider2D.enabled = true;
            //pc.enabled = true;

            //collisionToLines.drawingState = DrawingState.Drawing;
        }



        if (Input.GetMouseButton(0)) {

            Points2d.Add(mousepos2d);

                if (Vector3.Distance(mousePos, linePositions[linePositions.Count - 1]) > minDistance) {
                    AddPoint();
                    if (edgeCollider2D != null && Points2d.Count > 1) {
                        edgeCollider2D.points = Points2d.ToArray();
                    }
                }


        } else if (Input.GetMouseButtonUp(0)) {
            edgeCollider2D.enabled = false;
            lr.loop = true;
            circleDrawn = true;
            pc.enabled = false;
            //linePositions.Clear();
        }

        if (lr.loop == true) {
            pc.enabled = true;
            timer += Time.deltaTime;

            if (timer >= waitingTime) {
                lr.enabled = false;
                lr.loop = false;
                timer -= waitingTime;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            edgeCollider2D.enabled = false;
            lr.loop = true;
            circleDrawn = true;
            pc.SetPath(0, new Vector2[] { new Vector2(0, 0), new Vector2(0, 0) });
            edgeCollider2D.points = defaultPoints.ToArray();
            //linePositions.Clear();
        }

        void AddPoint() {
            linePositions.Add(mousePos);
            lr.positionCount = linePositions.Count; //pisteiden koko m‰‰r‰
            Vector3 lastPoint = linePositions[linePositions.Count - 1]; // Viimeinen listan piste
            lr.SetPosition(lr.positionCount - 1, lastPoint);
            pc.enabled = false;
        }

    }

}
