using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource source;
    public AudioClip mouseover;
    public AudioClip selected;
    public AudioClip dead;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = mouseover;
        source.volume = PlayerPrefs.GetFloat("sound_volume");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MouseOver() {
        source.clip = mouseover;
        source.Play();
    }

    public void Selected() {
        source.clip = selected;
        source.Play();
    }

    public void Dead() {
        source.clip = dead;
        source.Play();
    }
}
