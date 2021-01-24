using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float gameTime = 20;
    public float timer = 0;
    public float winPoints = 30;
    float endTime = 0;

    [SerializeField]
    Text countDownText;

    public GameObject ballPropertyHolder;
    public GameObject ballSpawner;
    public GameObject lose;
    public GameObject win;

    GameObject[] gameObjects;
    public Transform particles;
    private void Start() {
        timer = gameTime;
    }

    private void Update() {

            timer -= 1 * Time.deltaTime;
            countDownText.text = timer.ToString("0");


        if(timer <= 0) {
            timer = 0;
            ballSpawner.SetActive(false);
            ballPropertyHolder.SetActive(false);
            DestroyAllObjects();
            if ( ScoreCounter.scoreValue < winPoints) {
                print(" you lose ");
                lose.SetActive(true);
            }
            else {
                print(" you win ");
                win.SetActive(true);
            }
            // pysäytä scene
            // räjäytä pallot
            // näytäpistemäärä
        }
    }

    void DestroyAllObjects() {
        gameObjects = GameObject.FindGameObjectsWithTag("Ball1");
        
        for (var i = 0; i < gameObjects.Length; i++) {
            var boom = Instantiate(particles, gameObjects[i].transform.position, transform.rotation);
            Destroy(gameObjects[i]);
            Destroy(boom.gameObject, 1);
        }
    }

}
