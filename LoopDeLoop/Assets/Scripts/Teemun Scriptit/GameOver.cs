using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void Retry() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        }

    public void QuitGame() {
        Application.Quit();
        Debug.LogError("Game quit!");
        }

    }
