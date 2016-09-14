using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    Player player;
    public int damage = 1;
    bool touchingPlayer = false;

	// Use this for initialization
	void Start () {
	
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
    }

    public void Damage()
    {
        if (touchingPlayer)
        {
            player.Damage(damage);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
