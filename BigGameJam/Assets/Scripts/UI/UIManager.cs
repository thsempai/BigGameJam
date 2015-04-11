using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    public List<Transform> listTransform = new List<Transform>();

    public Transform jauge;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Collect() {
        listTransform.Add(jauge);
    }

    public void DesactiveAllUI() {
        foreach(Transform trans in listTransform) {
            trans.gameObject.SetActive(false);
        }
    }
}
