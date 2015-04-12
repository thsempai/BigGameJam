using UnityEngine;
using System.Collections;

public class TriggerGrandPlace : MonoBehaviour {

    public Transform laurent;
    public float newZ = 8.13f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform == laurent) {
            float z = newZ;
            float x = laurent.position.x;
            float y = laurent.position.y;

            laurent.position = new Vector3(x,y,z);
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
