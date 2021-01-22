using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour {
    GameObject propertyHolder;
    BallPropertiesCopy ballProperties;
    public BallColour2 colourValue;

    void Start() {
        
        }

    public void OneColour() {
        //colourValue = BallColour2.Blue;
        propertyHolder = GameObject.Find("BallPropertyHolder");
        ballProperties = propertyHolder.GetComponent<BallPropertiesCopy>();
        ballProperties.StartCoroutine("OneColourTimer");
        //ballProperties.ballColour = BallColour2.Blue;
        }

    public void TwoColours() {
        //colourValue = (BallColour2)Random.Range(0, 3);
        propertyHolder = GameObject.Find("BallPropertyHolder");
        ballProperties = propertyHolder.GetComponent<BallPropertiesCopy>();
        ballProperties.StartCoroutine("TwoColoursTimer");
        //ballProperties.ballColour = (BallColour2)Random.Range(0, 3);

        }

    public void ThreeColours() {
        //colourValue = (BallColour2)Random.Range(0, System.Enum.GetValues(typeof(BallColour2)).Length);
        propertyHolder = GameObject.Find("BallPropertyHolder");
        ballProperties = propertyHolder.GetComponent<BallPropertiesCopy>();
        ballProperties.StartCoroutine("ThreeColoursTimer");
        //ballProperties.ballColour = (BallColour2)Random.Range(0, System.Enum.GetValues(typeof(BallColour2)).Length);
        }
    }
