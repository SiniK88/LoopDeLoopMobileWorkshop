using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public GameObject[] touchVisual;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            MovePlayerRay(Input.mousePosition);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            MovePlayerWorld(Input.mousePosition);
        }

    }
    void MovePlayerRay(Vector3 rayVector) {
        Ray ray = Camera.main.ScreenPointToRay(rayVector);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            touchVisual[0].transform.position = hit.point;
            touchVisual[1].transform.position = hit.point;
        }
    }

    void MovePlayerWorld(Vector3 screenPos) {
        var worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        transform.position = new Vector3(worldPos.x, worldPos.y, 0);
    }
}
