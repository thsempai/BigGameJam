using UnityEngine;
using System.Collections;
using InControl;
using UnityStandardAssets._2D;

public class HitboxManager : MonoBehaviour {

    public PolygonCollider2D punchframe;
    public PolygonCollider2D kickframe;

    private PolygonCollider2D[] colliders;

    private PolygonCollider2D localCollider;

    public AudioSource kickSwoosh;
    public AudioSource kickHit;
    public AudioSource punchSwoosh;
    public AudioSource punchHit;
    private bool kick;


    public enum hitBoxes {
        hitboxFrame1,
        hitboxKick,
        clear // special case to remove all boxes
    }
    
    void Start() {
        // Set up an array so our script can more easily set up the hit boxes
        colliders = new PolygonCollider2D[]{punchframe, kickframe};

        // Create a polygon collider
        localCollider = gameObject.AddComponent<PolygonCollider2D>();
        localCollider.isTrigger = true; // Set as a trigger so it doesn't collide with our environment
        localCollider.pathCount = 0; // Clear auto-generated polygons
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CharacterPunch")
                                                || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CharacterKick")  )) {
            Debug.Log("Enemy hit something!");
            other.gameObject.GetComponent<Animator>().SetTrigger("GotHit");
            other.gameObject.GetComponent<Animator>().SetBool("Ground", false);
            if (GetComponent<PlatformerCharacter2D>().m_FacingRight) {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100.0f, 400f));
            } else {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100.0f, 400f));
            }
            if (kick) {
                kickHit.Play();
            } else {
                punchHit.Play();
            }
        } else
        if (other.gameObject.tag == "Enemy" && (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CharacterPunch")
                                                || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("CharacterKick"))) {
            if (gameObject.tag == "Enemy")
                return;
            Debug.Log("Collider hit something!");
            other.gameObject.GetComponent<Animator>().SetTrigger("GotHit");
            other.gameObject.GetComponent<Animator>().SetBool("Ground", false);
            if (GetComponent<PlatformerCharacter2D>().m_FacingRight) {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100.0f, 400f));
            } else {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100.0f, 400f));
            }
            other.gameObject.GetComponent<Platformer2DAIControl>().lostControl = true;
            other.gameObject.GetComponent<Platformer2DAIControl>().TakeDamage();
            if (kick) {
                kickHit.Play();
            } else {
                punchHit.Play();
            }
        }
    }

    public void launchPunch() {
        punchSwoosh.Play();
        kick = false;
    }

    public void launchKick() {
        kickSwoosh.Play();
        kick = true;
    }

    public void setHitBox(hitBoxes val) {
        if(val != hitBoxes.clear) {
            localCollider.SetPath(0, colliders[(int)val].GetPath(0));
            return;
        }
        localCollider.pathCount = 0;
    }
}
