using UnityEngine;
using System.Collections;

public class Bobina : MonoBehaviour {

    Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        float phi = Time.time / 3.0f * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.2F + 1.3F;
        light.intensity = amplitude;
    }
}
