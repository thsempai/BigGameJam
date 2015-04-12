using UnityEngine;
using System.Collections;

public class IrishSpawner : MonoBehaviour {

    public GameObject template;
    public EnemyCounter counter;

	// Update is called once per frame
	void Update () {
        if (Random.Range(0,250) == 25 && (counter.spawned < counter.goal)) {
            GameObject irish = (GameObject)Instantiate(template, transform.position, Quaternion.identity);
            irish.SetActive(true);
            counter.spawned += 1;
        }
	}
}
