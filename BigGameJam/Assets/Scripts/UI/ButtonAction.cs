using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour {

    public Animator animator;
    public Animator secondAnimator;

    public void ChangeScene(string levelName) {
         Application.LoadLevel(levelName);
    }

    public void ChangeScene(int levelId) {
         Application.LoadLevel(levelId);
    }

    public void ChangeAnimatorValue(string name) {
        animator.SetBool(name,true);

    }

    public void ChangeSecondAnimatorValue(string name) {
        secondAnimator.SetBool(name,true);

    }
}