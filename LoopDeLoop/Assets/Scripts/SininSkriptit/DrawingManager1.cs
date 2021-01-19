using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager1 : MonoBehaviour {
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    public List<Vector3> drawnLinesPos = new List<Vector3>();
    public List<Vector3> drawnLinesPosEnd = new List<Vector3>();
    Vector3 mousePos;
    public bool circleDrawn = false;
    public float tolerance = 0.5f;
    PolygonCollider2D polygonCollider;
    bool LineRExists = false;

    float waitingTime = 10f;
    float timer = 0;
    void Start() {

        polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
    }
    void Update() {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        if (Input.GetMouseButtonDown(0)) {
            drawnLinesPos.Add(mousePos);
            //GameObject drawing = Instantiate(drawingPrefab);
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            LineRExists = true;
        }
        if (Input.GetMouseButton(0)) {
            FreeDraw();

        } else {
            timer += Time.deltaTime;
            if (timer >= waitingTime) {
                //ClearAllPoints();
                //drawnLinesPos.Clear();
                //lineRenderer.SetPositions(new Vector3[] { });
                timer -= waitingTime;
            }
            if (Input.GetMouseButtonUp(0)) {

                if (Vector3.Distance(lineRenderer.GetPosition(0), lineRenderer.GetPosition(lineRenderer.positionCount - 1)) < 1f) {
                    lineRenderer.loop = true;

                }
            }
        }

        if (LineRExists == true) { 
            if (lineRenderer.loop == true) {
                lineRenderer.Simplify(tolerance);

                Vector2[] pos2 = new Vector2[lineRenderer.positionCount]; // muutetaan vector3[] pisteet Vector2[] pisteiksi niin, että niitä voi käyttää polygoncolliderissa

                for (int i = 0; i < lineRenderer.positionCount; i++) {
                    Vector3 tempv3 = lineRenderer.GetPosition(i);
                    pos2[i] = new Vector2(tempv3.x, tempv3.y);
                    //print(pos2[i]);
                }
                /*for (int i = 0; i < lineRenderer.positionCount; i++) {
                    drawnLinesPosEnd.Add(lineRenderer.GetPosition(i));
                    //print(drawnLinesPosEnd[i]);
                } */ 

                if (drawnLinesPosEnd.Count == lineRenderer.positionCount) {

                    polygonCollider.SetPath(0, pos2);
                }
            }
        }
    }   
    void FreeDraw() {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(mousePos));
    }

    private void ClearAllPoints() {


        //GameObject[] allPoints = GameObject.FindGameObjectsWithTag("Drawing");
        //for( var i = 0; i < allPoints.Length; i++) {
        //    Destroy(allPoints[i]);
        //    LineRExists = false;
        //}
    }
}
