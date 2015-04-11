using UnityEngine;
using System.Collections;

public class CinematicManager : MonoBehaviour {

    public UIManager uiManager;
    public Transform rain;

	// Use this for initialization
	void Start () {
	
    uiManager = GetComponent<UIManager>();
    uiManager.Collect();
    
    uiManager.DesactiveAllUI();
    rain.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
