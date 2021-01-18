using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines1 : MonoBehaviour
{

    private LineRenderer lineRenderer;
    List<Vector3> linesList = new List<Vector3>(); 

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        Vector3[] positions = new Vector3[3] { new Vector3(0, 0, 0), new Vector3(-1, 0, 0), new Vector3(1, 0, 0) };
        DrawTriengle(positions, 0.02f, 0.02f);
    }

    void DrawTriengle(Vector3[] vertexPositions, float startWidth, float endWidth) {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.loop = true;
        lineRenderer.positionCount = 3; 
        lineRenderer.SetPositions(vertexPositions);
    }

    void Update()
    {
        
    }


}
