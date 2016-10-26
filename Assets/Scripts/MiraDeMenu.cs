using UnityEngine;
using System.Collections;

public class MiraDeMenu : MonoBehaviour {

    public int index;
    public bool activated = false;
    public bool selected = false;
    public JuegoMenu juegoMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        if(!selected)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        activated = true;
    }

    void OnMouseExit()
    {
        if (!selected)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        activated = false;
    }

    void OnMouseUpAsButton()
    {
        selected = true;
        GetComponent<SpriteRenderer>().color = Color.green;
        juegoMenu.SelectedMira(this.index);
    }

    public void Select()
    {
        selected = true;
        activated = true;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void Deselect()
    {
        selected = false;
        activated = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
