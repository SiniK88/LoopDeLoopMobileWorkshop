using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideOfPolygonCollider : MonoBehaviour
{

    public int ballsInside;
    PolygonCollider2D pc;

    [SerializeField]
    private ContactFilter2D contactFilter;

    List<Vector2> offsets = new List<Vector2>();

    void Start() {

        pc = GetComponent<PolygonCollider2D>();
        //offsets = new List<Vector2> { Vector2.up * 0.5f, Vector2.right * 0.5f, Vector2.down * 0.5f, Vector2.left * 0.5f };
        for (int i = 0; i < 6; i++) {
            offsets.Add(new Vector2(0 + 0.5f * Mathf.Cos((i * 60) * (Mathf.PI / 180)), 0 + 0.5f * Mathf.Sin((i * 60) * (Mathf.PI / 180))));
        }

    }

    public List<GameObject> BallsInsidePolygon() {

        List<Collider2D> coll = new List<Collider2D>();
        int colliderCount = pc.OverlapCollider(contactFilter, coll);
        List<GameObject> inside = new List<GameObject>();
        foreach (var c in coll) {
            var p = c.transform.position;
            if (BallInside(p))
                inside.Add(c.gameObject);
        }
        print(" ball is touching polygon collider " + colliderCount);
        return inside;
    }

    bool BallInside(Vector2 position) {
        // check all offsets, return false if any outside the polygon collider
        for (int i = 0; i < offsets.Count; i++) {
            var test = pc.OverlapPoint(position + offsets[i]);
            if (!test)
                return false; 
           // print("offsets" + offsets[i]);
        }
        return true;
    }

    private void FixedUpdate() {
        var results = BallsInsidePolygon();
        ballsInside = results.Count;
        print("koko pallo sisiällä " + ballsInside); 
    }


} // class
