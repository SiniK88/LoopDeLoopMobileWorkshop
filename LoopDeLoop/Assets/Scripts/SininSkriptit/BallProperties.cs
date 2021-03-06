using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallColour2 { Blue, Red, Yellow };
public class BallProperties : MonoBehaviour
{
    public BallColour2 ballColour;
    public Material[] materials;
    public Sprite[] sprites;
    SpriteRenderer rend;
    public bool randomBool = true;  

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        

        if(randomBool == true) {
            ballColour = (BallColour2) Random.Range(0, System.Enum.GetValues(typeof(BallColour2)).Length);
        }

        rend.material = materials[(int)ballColour];
        rend.sprite = sprites[(int)ballColour];
    }
    //System.Enum.GetValues(typeof(Enemy)).Length


}
