using System.Collections.Generic;
using UnityEngine;

public class CapacitorGhost : MonoBehaviour
{   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Set(string animation)
    {
        GetComponent<Animator>().Play("capacitor_muerte_" + animation);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}