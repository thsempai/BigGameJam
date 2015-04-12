using UnityEngine;
using System.Collections;

public class Dialog104 : MonoBehaviour {

    public CinematicManager manager;

    public Platformer2DAIControl drunkenIrish;

    public void irishGoTo() {
        drunkenIrish.state = Platformer2DAIControl.states.go_to_laurent;
    }

    public void irishSmackdown() {
        drunkenIrish.state = Platformer2DAIControl.states.single_punch;
    }

}
