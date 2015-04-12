using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Dialog104 : MonoBehaviour {

    public CinematicManager manager;

    public Platformer2DAIControl drunkenIrish; 
    public Platformer2DAIControl drunkenIrishRedux;
    public Platformer2DUserControl laurent;

    public GameObject[] toEnable;

    public void irishGoTo() {
        drunkenIrish.state = Platformer2DAIControl.states.go_to_laurent;
    }

    public void irishSmackdown() {
        drunkenIrish.state = Platformer2DAIControl.states.single_punch;
    }

    public void irishFlip() {
        drunkenIrish.gameObject.GetComponent<PlatformerCharacter2D>().Flip();
    }

    public void LetsGetDownToBusiness() {
        manager.uiManager.SetAllUIActive(true);
        drunkenIrish.state = Platformer2DAIControl.states.retreat;
        drunkenIrishRedux.state = Platformer2DAIControl.states.retreat;
        laurent.enabled = true;
        foreach(GameObject go in toEnable) {
            if (go)
                go.SetActive(true);
        }
    }

}
