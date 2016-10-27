using UnityEngine;
using System.Collections;

public class BarritaScript : MonoBehaviour {

    public int index;
    public int direction;
    public AudioMenu audioMenu;

    // Use this for initialization
    void Start () {
        audioMenu = GameObject.Find("Main Camera").GetComponent<AudioMenu>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseOver()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float x = Input.GetAxis("Mouse ScrollWheel");
            if (x > 0)
            {
                audioMenu.clickedBarrita(index, 1);
            } else
            {
                audioMenu.clickedBarrita(index, -1);
            }
        }
    }
}
