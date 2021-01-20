using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer1 : MonoBehaviour
{
    LineRenderer lr;
    public List<Vector3> linePositions = new List<Vector3>();
    Vector3 mousePos;
    public GameObject drawPrefab;
    public float minDistance = 0.2f;

    public bool circleDrawn = false;

    EdgeCollider2D edgeCollider2D;
    public List<Vector2> Points2d;
    void Start() {
        var drawing = Instantiate(drawPrefab);
        lr = drawing.GetComponent<LineRenderer>();
        edgeCollider2D = drawing.GetComponent<EdgeCollider2D>();
        Points2d = new List<Vector2>();
    }


    void Update() {
        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.4f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 mousepos2d = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {

                circleDrawn = false;
                lr.loop = false;
                linePositions.Clear();
                lr.SetPositions(new Vector3[] { });

                AddPoint();
                Points2d.Clear();
                edgeCollider2D.enabled = true;
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

                //linePositions.Clear();
            }
        


            void AddPoint() {
            linePositions.Add(mousePos);
            lr.positionCount = linePositions.Count; //pisteiden koko m‰‰r‰
            Vector3 lastPoint = linePositions[linePositions.Count - 1]; // Viimeinen listan piste
            lr.SetPosition(lr.positionCount - 1, lastPoint);
        }

    }

}
