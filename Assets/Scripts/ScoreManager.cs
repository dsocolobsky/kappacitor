using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject botonAtras;
    MenuItem atras;
    public GameObject ind_left;
    public GameObject ind_right;
    public GameObject icon_led;
    public GameObject icon_capacitor;
    public Text deadbytext;

    // Use this for initialization
    void Start()
    {
        atras = botonAtras.GetComponent<MenuItem>();

        Text scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        string score = PlayerPrefs.GetString("score");
        scoreText.text = "PUNTAJE: " + score;

        int deadbyindex = PlayerPrefs.GetInt("deadby", 1);
        if (deadbyindex == 1)
        {
            deadbytext.text = "Capacitor Electrolitico";
            icon_capacitor.GetComponent<SpriteRenderer>().enabled = true;
        } else if (deadbyindex == 2)
        {
            deadbytext.text = "Diodo Led";
            icon_led.GetComponent<SpriteRenderer>().enabled = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") || (Input.GetMouseButtonDown(0) && atras.activated))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        {
            if (atras.activated)
            {
                ind_left.GetComponent<SpriteRenderer>().enabled = true;
                ind_right.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                ind_left.GetComponent<SpriteRenderer>().enabled = false;
                ind_right.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}