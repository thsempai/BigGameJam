using UnityEngine;
using System.Collections;
using InControl;

public class HitboxManager : MonoBehaviour {

    public PolygonCollider2D punchframe;

    private PolygonCollider2D[] colliders;

    private PolygonCollider2D localCollider;

    public AudioSource kickSwoosh;
    public AudioSource kickHit;

    public enum hitBoxes {
        hitboxFrame1,
        clear // special case to remove all boxes
    }
    
    void Start() {
        // Set up an array so our script can more easily set up the hit boxes
        colliders = new PolygonCollider2D[]{punchframe};

        // Create a polygon collider
        localCollider = gameObject.AddComponent<PolygonCollider2D>();
        localCollider.isTrigger = true; // Set as a trigger so it doesn't collide with our environment
        localCollider.pathCount = 0; // Clear auto-generated polygons
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Collider hit something!");
        kickHit.Play();
    }

    public void launchPunch() {
        kickSwoosh.Play();
    }

    public void setHitBox(hitBoxes val) {
        if(val != hitBoxes.clear) {
            localCollider.SetPath(0, colliders[(int)val].GetPath(0));
            return;
        }
        localCollider.pathCount = 0;
    }
}
