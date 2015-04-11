using UnityEngine;
using System.Collections;

public class JaugeAction : MonoBehaviour {

    public void UpdateJauge(float pc) {
    GetComponent<UnityEngine.UI.Slider>().value = pc;
    }
}

