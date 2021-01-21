using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchIndicator : MonoBehaviour {
    Vector3 mousePos;
    public GameObject indicator;
    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (Input.GetMouseButtonDown(0)){
            indicator.SetActive(true);
            } 
        else if (Input.GetMouseButtonUp(0)) {
            indicator.SetActive(false);
            }

        if (Input.GetMouseButton(0)) {
            gameObject.transform.position = mousePos;
            }

        }
    }
