using UnityEngine;
using System.Collections;

public class Insert1 : MonoBehaviour {

    public AudioSource explosion;
    public AudioSource laser;

    public CinematicManager manager;

    public Animator dialog2;

    public void PlaySFX() {
        explosion.Play();
        laser.Play();
    }

    public void SwitchCamera() {
        manager.SwitchToCamera(1);
        dialog2.SetTrigger("Start");
        gameObject.SetActive(false);
    }

}
