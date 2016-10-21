using UnityEngine;
using System.Collections;

public class EnemyBullet : Bullet {

	// Use this for initialization
	void Start () {
        screenPoint = transform.position;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        direction = (player.transform.position - screenPoint).normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "enemy" || col.gameObject.tag != "drop")
        {
            doDestroy = true;
            GetComponent<SpriteRenderer>().sprite = exploded;
            audioSource.Play(0);
        }
    }
}
