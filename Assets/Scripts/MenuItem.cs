using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour
{

    public int index;
    public bool activated = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        activated = true;
    }

    void OnMouseExit()
    {
        activated = false;
    }


}