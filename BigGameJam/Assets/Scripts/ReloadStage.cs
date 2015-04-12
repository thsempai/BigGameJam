using UnityEngine;
using System.Collections;

public class ReloadStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Reload()
        {
            string stage = PlayerPrefs.GetString("stage");
            Debug.Log("Reload "+stage+"!");
            Application.LoadLevel(stage);
        }

    public void quit() {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
