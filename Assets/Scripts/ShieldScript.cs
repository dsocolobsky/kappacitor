using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour {

    SpriteRenderer sprite;
    BoxCollider2D[] colliders;
    public int hitpoints = 3;
    public bool isDeleted = false;

    ParticleSystem particle_hit;
    ParticleSystem particle_broke;

    // Use this for initialization
    void Start () {
        sprite = GetComponentInParent<SpriteRenderer>();
        colliders = GetComponents<BoxCollider2D>();

        particle_hit = transform.Find("particle_hit").GetComponent<ParticleSystem>();
        particle_broke = transform.Find("particle_broke").GetComponent<ParticleSystem>();

        Disable();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Enable()
    {
        sprite.enabled = true;
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = true;
        }
    }

    public void Disable()
    {
        sprite.enabled = false;
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemybullet")
        {
            Hit();
        }
    }

    void Hit()
    {
        hitpoints--;
        GetComponent<ShieldPulse>().Execute();

        particle_hit.Play();

        if (hitpoints < 0)
        {
            particle_broke.Play();
            Disable();
            isDeleted = true;
        }
    }
}
