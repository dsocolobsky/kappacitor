using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cargador : MonoBehaviour {

    public int maxBalas = 6;
    public int actualBalas = 6;

    GameObject bala_6;
    GameObject bala_5;
    GameObject bala_4;
    GameObject bala_3;
    GameObject bala_2;
    GameObject bala_1;
    GameObject[] balas;

    // Use this for initialization
    void Start () {
        balas = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            int j = i + 1;
            balas[i] = transform.Find("bala_" + j.ToString()).gameObject;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GastarBala()
    {
        if (actualBalas > 0)
        {
            GameObject b = balas[actualBalas-1];
            b.GetComponent<Image>().enabled = false;
            actualBalas--;
        }
    }

    public void Reload()
    {
        actualBalas = maxBalas;

        foreach (GameObject bala in balas)
        {
            bala.GetComponent<Image>().enabled = true;
        }
    }
}
