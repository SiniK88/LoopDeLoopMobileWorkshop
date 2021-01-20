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

    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line
    void Start() {
        var drawing = Instantiate(drawPrefab);
        lr = drawing.GetComponent<LineRenderer>();
    }

    void Update() {
        //mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.4f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (Input.GetMouseButtonDown(0)) {
            circleDrawn = false;
            lr.loop = false;
            linePositions.Clear();
            lr.SetPositions(new Vector3[] { });
            AddPoint();
            startPos = mousePos;
        }

        if (Input.GetMouseButton(0)) {
            if (Vector3.Distance(mousePos, linePositions[linePositions.Count - 1]) > minDistance) {
                AddPoint();
                endPos = mousePos;
                addColliderToLine();
            }
        } else if (Input.GetMouseButtonUp(0)) {
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
    private void addColliderToLine() {
        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();
        col.transform.parent = lr.transform; // Collider is added as child object of line
        float lineLength = Vector3.Distance(startPos, endPos); // length of line
        col.size = new Vector3(lineLength, 0.1f, 1f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between startPos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x)) {
            angle *= -1;
        }
        angle = Mathf.Rad2Deg * Mathf.Atan(angle);
        col.transform.Rotate(0, 0, angle);
    }

}
