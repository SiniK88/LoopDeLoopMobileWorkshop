using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public GameObject ball;
    public float spawnTime;
       
    public IEnumerator Timer() {
        var ballCopy = Instantiate(ball);
        ballCopy.transform.position = transform.position;
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(Timer());
        }

    void Start() {
        StartCoroutine(Timer());
        }
    }
