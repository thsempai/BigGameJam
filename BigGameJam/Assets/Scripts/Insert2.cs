using UnityEngine;
using System.Collections;

public class Insert2 : MonoBehaviour {

    //public AudioSource explosion;
    //public AudioSource laser;

    public CinematicManager manager;
    public GameObject laurent;
    public Animator dialog3;

    public GameObject rain;
    public Animator[] cutouts;


    public void makeLooping() {
        foreach (Animator animator in cutouts) {
            animator.SetInteger("Cycle", 1);
            dialog3.SetTrigger("Start");
        }
    }

    public void SwitchCamera() {
        manager.SwitchToCamera(2);
        laurent.SetActive(true);
        //dialog2.SetTrigger("Start");
        rain.SetActive(false);
        gameObject.SetActive(false);
    }

}
