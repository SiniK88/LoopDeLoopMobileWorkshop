using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameOverTest : MonoBehaviour {
    public GameObject GameOverMenu;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            }
        }
    }
