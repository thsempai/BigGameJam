using UnityEngine;
using System.Collections;

public class LaurentLife : MonoBehaviour {

    public Transform jauge;

    public int damageByHit = 10;
    public int lifeMax = 150;
    public int life;


	// Use this for initialization
	void Start () {
	life = lifeMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LaurentTakeDamage() {
        life -= damageByHit;
        if (life < 0) {
            {
            life = 0;
            GameOver();
            }
        }
        jauge.GetComponent<JaugeAction>().UpdateJauge((float)life/(float)lifeMax*100f);
    }

    public void GameOver() {

    }
}