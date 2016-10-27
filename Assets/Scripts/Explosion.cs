using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    Player player;
    public int damage = 1;
    bool touchingPlayer = false;

	// Use this for initialization
	void Start () {
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("sound_volume");
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name.StartsWith("player") && !touchingPlayer)
        {
            touchingPlayer = true;
            player = col.gameObject.GetComponent<Player>();
        }

        if (col.gameObject.name.StartsWith("led"))
        {
            col.gameObject.GetComponent<Led>().Explode();
        }
    }

    public void Damage()
    {
        if (touchingPlayer)
        {
            player.Damage(damage, 2);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
