using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet {

	// Use this for initialization
	void Start () {
        screenPoint = transform.position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        direction = (player.transform.position - screenPoint).normalized;

        Debug.Log(direction);

        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "enemy")
        {
            doDestroy = true;
            GetComponent<SpriteRenderer>().sprite = exploded;
            audio.Play(0);
        }
    }
}
