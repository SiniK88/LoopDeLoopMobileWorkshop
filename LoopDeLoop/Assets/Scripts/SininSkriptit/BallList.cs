using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallList : MonoBehaviour
{
    public List<Transform> pallot = new List<Transform>();


    void Start()
    {
        //HereisBall[] pallo = FindObjectsOfType<HereisBall>();
        //foreach (var pc in pallo) {
        //   pallot.Add(pc.transform);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBalls();

    }

    void UpdateBalls() {
        pallot.Clear();
        GameObject[] pallo = GameObject.FindGameObjectsWithTag("Ball1");
        foreach (var pc in pallo) {
            pallot.Add(pc.transform);
        }
    }


}
