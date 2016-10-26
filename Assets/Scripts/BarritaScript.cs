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

    void OnMouseUpAsButton()
    {
        audioMenu.clickedBarrita(index, direction);
    }
}
