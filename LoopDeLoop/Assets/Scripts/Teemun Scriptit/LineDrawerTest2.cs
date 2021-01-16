using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerTest2 : MonoBehaviour {
    LineRenderer lr;
    public List<Vector2> linePos = new List<Vector2>();
    Vector3 mousePos;
    public GameObject drawPrefab;
    
    void Start() {
        lr = drawPrefab.GetComponent<LineRenderer>();
        }

    void Update() {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lr.positionCount = linePos.Count;

        if (Input.GetMouseButtonDown(0)) {
            var drawing = Instantiate(drawPrefab);
            linePos.Add(mousePos);
            //print(linePos.IndexOf(mousePos));
            }

        if (Input.GetMouseButton(0)) {
            Line();
            }
        else if (Input.GetMouseButtonUp(0)) {
            lr.loop = true;

            }

        void Line() {
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            linePos.Add(mousePos);
            lr.SetPosition(linePos.IndexOf(mousePos) -1, Camera.main.ScreenToWorldPoint(mousePos));
            }

        }
    }
