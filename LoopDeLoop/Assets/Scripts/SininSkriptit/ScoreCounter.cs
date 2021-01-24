using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    public GameObject timer;
    float winPoints;
    void Start()
    {
        score = GetComponent<Text>();
        winPoints = timer.GetComponent<GameTimer>().winPoints;
    }

    // Update is called once per frame
    void Update()
    {
        //var winPoints = timer.GetComponent<GameTimer>().winPoints;
        score.text = "Score: " + scoreValue + "/" + winPoints;
        if (scoreValue >= winPoints) {
            score.color = Color.green;
        }
    }
}
