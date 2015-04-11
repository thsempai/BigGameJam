using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour {

    public void ChangeScene(string levelName) {
         Application.LoadLevel(levelName);
    }

    public void ChangeScene(int levelId) {
         Application.LoadLevel(levelId);
    }
}