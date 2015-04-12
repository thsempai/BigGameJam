using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Dialog202 : MonoBehaviour {

    public Animator sensei;
    public Platformer2DUserControl laurent;
        public  GameObject orange;
    public AudioSource bgm;
    // Use this for initialization
    void SenseiTransform () {
       sensei.SetTrigger("Start");
    }
    
    void SenseiTakeoff()  {

    }

    void Finish() {
        laurent.enabled = true;
        sensei.SetTrigger("Takeoff");
        orange.SetActive(true);
        bgm.Play();
    }
}
