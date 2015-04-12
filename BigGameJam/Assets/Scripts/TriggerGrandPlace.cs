using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class TriggerGrandPlace : MonoBehaviour {

    public Transform laurent;
    public float newZ = 8.13f;
    public Platformer2DUserControl laurentcontrols;

    public Animator dialog;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform == laurent) {
            float z = newZ;
            float x = 38f;//laurent.position.x;
            float y = laurent.position.y;

            laurent.position = new Vector3(x,y,z);
            laurentcontrols.enabled=false;
            dialog.SetTrigger("Start");
            Destroy(gameObject);
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
