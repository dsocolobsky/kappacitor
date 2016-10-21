using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float volume = PlayerPrefs.GetFloat("music_volume");
        GetComponent<AudioSource>().volume = volume;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
