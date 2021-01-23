using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPropertiesCopy : MonoBehaviour
{
    public BallColour2 ballColour;
    public Sprite[] sprites;
    //public Material[] materials;
    //public DifficultyButtons dButtons;
    //MeshRenderer rend;
    //public bool randomBool = true;
    GameObject spawner;
    BallSpawner spawnerScript;

    public IEnumerator OneColourTimer() {
        spawner = GameObject.Find("Ball Spawner 2");
        spawnerScript = spawner.GetComponent<BallSpawner>();
        yield return new WaitForSeconds(spawnerScript.spawnTime);
        //if (randomBool == true) {
        //    ballColour = (BallColour2)Random.Range(0, System.Enum.GetValues(typeof(BallColour2)).Length);
        //    }
        ballColour = BallColour2.Blue;
        StartCoroutine(OneColourTimer());
        }

    public IEnumerator TwoColoursTimer() {
        spawner = GameObject.Find("Ball Spawner 2");
        spawnerScript = spawner.GetComponent<BallSpawner>();
        ballColour = (BallColour2)Random.Range(0, 2);
        yield return new WaitForSeconds(spawnerScript.spawnTime);
        StartCoroutine(TwoColoursTimer());
        }

    public IEnumerator ThreeColoursTimer() {
        spawner = GameObject.Find("Ball Spawner 2");
        spawnerScript = spawner.GetComponent<BallSpawner>();
        ballColour = (BallColour2)Random.Range(0, System.Enum.GetValues(typeof(BallColour2)).Length);
        yield return new WaitForSeconds(spawnerScript.spawnTime);
        StartCoroutine(ThreeColoursTimer());
        }

    //void Awake() {
    //    spawner = GameObject.Find("Ball Spawner 2");
    //    spawnerScript = spawner.GetComponent<BallSpawner>();
    //    //rend = GetComponent<MeshRenderer>();

    //    //if (randomBool == true) {
    //    //    ballColour = (BallColour2)Random.Range(0, System.Enum.GetValues(typeof(BallColour2)).Length);
    //    //    }

    //    //rend.material = materials[(int)ballColour];
    //    }

    }
