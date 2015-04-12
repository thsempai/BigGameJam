using UnityEngine;
using System.Collections;

public class Insert2 : MonoBehaviour {

    //public AudioSource explosion;
    //public AudioSource laser;

    public CinematicManager manager;
    public GameObject laurent;
    //public Animator dialog2;


    public void SwitchCamera() {
        manager.SwitchToCamera(2);
        laurent.SetActive(true);
        //dialog2.SetTrigger("Start");
        gameObject.SetActive(false);
    }

}
