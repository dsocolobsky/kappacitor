using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn()
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
