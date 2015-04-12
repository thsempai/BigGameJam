using UnityEngine;
using System.Collections;

public class CinematicCutout : MonoBehaviour {

    public Animator[] animatorsToStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ActivateCutouts() {
        foreach (Animator animator in animatorsToStart) {
            animator.SetTrigger("Start");
        }
    }
}
