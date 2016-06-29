using UnityEngine;
using System.Collections;

public class DropItem : MonoBehaviour {

    public GameObject escudo;
    public GameObject media;
    public GameObject full;
    public GameObject player;
    public int chance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Drop()
    {
        int n = random(1, 100);
        if (n <= chance)
        {
            int o = random(1, 100);
            if (o <= chance/2)
            {
                dropItem(escudo);
            } else // Alguna vida
            {
                int m = random(0, 1);
                if (m == 0)
                {
                    dropItem(media);
                } else
                {
                    dropItem(full);
                }
            }
        }
    }

    int random(int min, int max)
    {
        return Mathf.FloorToInt(Random.Range(min, max));
    }

    void dropItem(GameObject item)
    {
        Instantiate(item, transform.position, Quaternion.identity);
    }

}
