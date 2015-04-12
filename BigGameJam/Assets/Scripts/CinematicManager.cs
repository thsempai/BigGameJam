using UnityEngine;
using System.Collections;

public class CinematicManager : MonoBehaviour {

    public UIManager uiManager;
    public Transform rain;
    public Animator camere101;
    public Animator dialogue1;

    public Camera[] cameras;

	// Use this for initialization
	void Start () {
	
        uiManager = GetComponent<UIManager>();
        uiManager.Collect();

        uiManager.DesactiveAllUI();
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

	// Update is called once per frame
	void Update () {
	
    if (camere101.GetBool("end traveling")) {
            dialogue1.SetBool("talk",true);
    }

	}
}
