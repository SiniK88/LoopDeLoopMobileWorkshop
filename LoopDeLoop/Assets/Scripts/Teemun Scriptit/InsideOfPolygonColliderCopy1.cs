using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideOfPolygonColliderCopy1 : MonoBehaviour {
    public int ballsInside;
    PolygonCollider2D pc;
    LineRenderer lr;
    GameObject spawner;
    BallSpawner spawnerScript;
    public Transform particles;
    public ScreenShaker shaker;

    [SerializeField]
    private ContactFilter2D contactFilter; // A set of parameters for filtering contact results. Mitk‰ kontaktitavat huomioidaan, tyyliin layermask tai trigger. 

    List<Vector2> offsets = new List<Vector2>();

    void Start() {
        spawner = GameObject.Find("Ball Spawner 2");
        spawnerScript = spawner.GetComponent<BallSpawner>();

        pc = GetComponent<PolygonCollider2D>();
        lr = GetComponent<LineRenderer>();
        //offsets = new List<Vector2> { Vector2.up * 0.5f, Vector2.right * 0.5f, Vector2.down * 0.5f, Vector2.left * 0.5f };
        for (int i = 0; i < 6; i++) {
            offsets.Add(new Vector2(0 + 0.3f * Mathf.Cos((i * 60) * (Mathf.PI / 180)), 0 + 0.3f * Mathf.Sin((i * 60) * (Mathf.PI / 180))));
            // offset ns. siirros. Kuinka paljon siirtyy keskipisteest‰ tiettyyn suuntaan. Katsotaan 6 siirrosta ympyr‰n keh‰lt‰ kun radius (s‰de) on 0.5
            }


        }
    public List<BallBehaviourRandomMovingCopy1> BallsInsidePolygon() {

        List<Collider2D> coll = new List<Collider2D>(); // lista jossa collider2D juttuja
        int colliderCount = pc.OverlapCollider(contactFilter, coll);  // overlapcollider = Get a list of all colliders that overlap this collider. Kaikki colliderit jotka osuu polygoncollideriin
        List<BallBehaviourRandomMovingCopy1> inside = new List<BallBehaviourRandomMovingCopy1>(); // uusi lista niille GameObjecteille jotka ovat sis‰ll‰
        foreach (var c in coll) { // k‰yd‰‰ l‰pi jokainen collider joka osuu polygoncollideriin ja katsotaan sen paikka
            var p = c.transform.position;
            if (BallInside(p))
                inside.Add(c.GetComponent<BallBehaviourRandomMovingCopy1>()); // laitetaan kaikki ne gameobjectit inside listan sis‰‰n joissa jokainen piste osui pc:iin
            }
        //print(" ball is touching polygon collider " + colliderCount);
        return inside;
        }

    bool BallInside(Vector2 position) {
        // check all offsets, return false if any outside the polygon collider
        for (int i = 0; i < offsets.Count; i++) {
            var test = pc.OverlapPoint(position + offsets[i]); // testataan jos polygon collideriin osuvan colliderin keskipisteest‰ suuntiin offsets[i] kaikki pisteet osuvat. Silloin tru
            if (!test) // jos yksik‰‰n piste ei osu niin palautetaan false
                return false;
            }
        return true;
        }
    private void FixedUpdate() {
        var results = BallsInsidePolygon();
        ballsInside = results.Count;
        //print("palloja sis‰ll‰" + ballsInside);

        var ballCheckResults = BallsCheck(results);
        //print("ball check result" + ballCheckResults);
        if (ballCheckResults == true && results.Count == 2) {
            ScoreCounter.scoreValue += 10;
            for (int i = 0; i < results.Count; i++) {
                var boom = Instantiate(particles, results[i].transform.position, transform.rotation);
                Destroy(boom.gameObject, 1);
                print("t‰ss‰ pit‰isi tuhota pallo " + results[i]);
                //Destroy(results[i].transform.parent.gameObject);
                Destroy(results[i].gameObject);
                spawnerScript.ballCount--;
                }
            }

        }

    bool BallsCheck(List<BallBehaviourRandomMovingCopy1> lista) {
        if (lista.Count == 2) {
            var h1 = (int)lista[0].ballColour;
            var h2 = (int)lista[1].ballColour;
            //r h3 = (int)lista[2].ballColour;

            if ((h1 == h2)) {
                // ( (h1 == h2) && (h2 == h3)) {
                return true;
                }
            /*for ( int i = 0; i < lista.Count; i++) {
                if( (int)lista[i].ballColour == (int)lista[i+1].ballColour  ) {
                    return true;
                }
            }*/
            }
        return false;
        // katso onko palloja oikea m‰‰r‰ ja ett‰ ne ovat samaa v‰ri‰. Jos vaikka tasan 3 palloa. Katso onko kolme palloa
        //sitten esim. ekan pallon v‰ri talteen muuttujaan, loopataan l‰pi. Jos yksikin pallo oli v‰‰rin, palauttaa falsen
        }

    } // class
