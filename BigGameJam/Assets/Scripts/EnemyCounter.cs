﻿using UnityEngine;
using System.Collections;

public class EnemyCounter : MonoBehaviour {

    public int goal = 20;
    public int dead;
    public int spawned= 2;

    public Animator lastDialog;

	// Use this for initialization
	void Start () {
	   dead = 0;
	}
	
	// Update is called once per frame
	void Update () {
	   if (dead >= goal) {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
            if (objects.Length == 0) {
                lastDialog.SetTrigger("Start");
            }

        }
	}
}
