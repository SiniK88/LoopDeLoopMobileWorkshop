using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerTest2 : MonoBehaviour {
    LineRenderer lr;
    public List<Vector3> linePos = new List<Vector3>();
    Vector3 mousePos;
    public GameObject drawPrefab;
    
    void Start() {
        lr = drawPrefab.GetComponent<LineRenderer>();
        }

    void Update() {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        lr.positionCount = linePos.Count;

        if (Input.GetMouseButtonDown(0)) {
            var drawing = Instantiate(drawPrefab);
            linePos.Add(mousePos);
            lr.SetPosition(linePos.IndexOf(mousePos), Camera.main.ScreenToWorldPoint(mousePos));
            //print(linePos.IndexOf(mousePos));
            }

        if (Input.GetMouseButton(0)) {
            Line();
            }

        void Line() {
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            //lr.SetPosition(linePos.IndexOf(mousePos), Camera.main.ScreenToWorldPoint(mousePos));
            }

        }
    }
