using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerTest : MonoBehaviour {

    LineRenderer lineRenderer;
    Vector3 mousePos;
    PolygonCollider2D polyCollider;
    public GameObject drawingPrefab;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var drawing = Instantiate(drawingPrefab);
            drawing.transform.position = mousePos;
            lineRenderer = drawing.GetComponent<LineRenderer>();
            }

        if (Input.GetMouseButton(0)) {
            FreeDraw();
            } 
        else if (Input.GetMouseButtonUp(0)) {
            lineRenderer.loop = true;
            //polyCollider = lineRenderer.gameObject.AddComponent<PolygonCollider2D>();
            //var drawing = drawingPrefab;
            //drawing.AddComponent<PolygonCollider2D>();
            }
        }

        
    void FreeDraw() {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount -1, Camera.main.ScreenToWorldPoint(mousePos));
        }

    }
