﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
