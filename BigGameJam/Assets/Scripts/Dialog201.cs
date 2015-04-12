using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class Dialog201 : MonoBehaviour {

    public Animator animator;
    public Platformer2DUserControl laurent;
    public Animator beer;
	// Use this for initialization
	void Start () {
	   animator.SetTrigger("Start");
	}
	
    public void Finish() {
        laurent.enabled = true;
        gameObject.SetActive(false);
        beer.SetTrigger("Rise");
    }



	// Update is called once per frame
	void Update () {
	
	}
}
