using UnityEngine;
using System.Collections;

public class DroppeableItem : MonoBehaviour {

    public enum Type
    {
        ESCUDO,
        MEDIA,
        FULL
    }

    public Type type;

    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        bool delete = false;

        if (col.gameObject.tag == "Player")
        {
            switch (type) {
                case Type.ESCUDO:
                    break;
                case Type.MEDIA:
                    delete = player.addHitpoints(1);
                    break;
                case Type.FULL:
                    delete = player.addHitpoints(2);
                    break;
            }

            if (delete)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
