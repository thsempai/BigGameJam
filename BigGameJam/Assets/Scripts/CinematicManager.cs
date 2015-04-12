using UnityEngine;
using System.Collections;
using InControl;
using UnityStandardAssets._2D;

public class CinematicManager : MonoBehaviour {

    public UIManager uiManager;
    public Transform rain;
    public Animator camere101;
    public Animator dialogue1;

    public Platformer2DUserControl laurent;
    public Platformer2DAIControl drunkenIrish; 
    public Platformer2DAIControl drunkenIrishRedux;

    public Camera[] cameras;
    public GameObject[] toDisableIfSkip;
    public GameObject[] toEnableIfSkip;

    public bool canSkipIntro = false;

	// Use this for initialization
	void Start () {
	
        uiManager = GetComponent<UIManager>();
        uiManager.Collect();

        uiManager.SetAllUIActive(false);
        rain.gameObject.SetActive(false);

        SwitchToCamera(0);
	}
	
    public void SwitchToCamera(int camIndex) {
        foreach (Camera camera in cameras) {
            if (camera == cameras[camIndex]) {
                camera.enabled = true;
            } else {
                camera.enabled = false;
            }
        } 
    }

    public void EnableRain() {
        rain.gameObject.SetActive(true);
    }

    public void CanSkipIntro(bool val) {
        canSkipIntro = val;
    }

    public void SkipIntro() {
        Debug.Log("Skip Intro");
        foreach(GameObject go in toDisableIfSkip) {
            if (go)
                go.SetActive(false);
        }
        foreach(GameObject go in toEnableIfSkip) {
            if (go)
                go.SetActive(true);
        }
        laurent.gameObject.SetActive(true);
        SwitchToCamera(2);
        uiManager.SetAllUIActive(true);
        rain.gameObject.SetActive(true);
        drunkenIrish.state = Platformer2DAIControl.states.retreat;
        drunkenIrishRedux.state = Platformer2DAIControl.states.retreat;
        laurent.enabled = true;
    }

	// Update is called once per frame
	void Update () {
	
        if (canSkipIntro && (InputManager.ActiveDevice.Action2.WasPressed || Input.GetKeyDown(KeyCode.X))) {
            SkipIntro();
        }
        if (camere101.GetBool("end traveling")) {
                dialogue1.SetBool("talk",true);
        }

	}
}
