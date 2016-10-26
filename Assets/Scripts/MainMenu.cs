﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    int ind_index = 0;
    GameObject[] left_indicators;
    GameObject[] right_indicators;

    MenuItem[] items;

	// Use this for initialization
	void Start () {
        items = new MenuItem[4];
        items[0] = GameObject.Find("jugar").GetComponent<MenuItem>();
        items[1] = GameObject.Find("opciones").GetComponent<MenuItem>();
        items[2] = GameObject.Find("highscore").GetComponent<MenuItem>();
        items[3] = GameObject.Find("salir").GetComponent<MenuItem>();

        left_indicators = new GameObject[4];
        right_indicators = new GameObject[4];

        for (int i = 0; i <= 3; i++)
        {
            left_indicators[i] = GameObject.Find("ind_left_" + i.ToString());
            right_indicators[i] = GameObject.Find("ind_right_" + i.ToString());
        }

        ind_index = 0;

        if (!PlayerPrefs.HasKey("sound_volume"))
        {
            PlayerPrefs.SetFloat("sound_volume", 1.0f);
            PlayerPrefs.SetFloat("music_volume", 1.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0))
        {
            switch (ind_index)
            {
                case 0:
                    SceneManager.LoadScene("test", LoadSceneMode.Single);
                    break;
                case 1:
                    SceneManager.LoadScene("OpcionesMenu", LoadSceneMode.Single);
                    break;
                case 2:
                    SceneManager.LoadScene("Highscore", LoadSceneMode.Single);
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                ind_index++;
                if (ind_index > 3)
                    ind_index = 3;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                ind_index--;
                if (ind_index < 0)
                    ind_index = 0;
            }

            for (int i = 0; i <= 3; i++)
            {
                if (i == ind_index)
                {
                    left_indicators[i].GetComponent<SpriteRenderer>().enabled = true;
                    right_indicators[i].GetComponent<SpriteRenderer>().enabled = true;
                } else
                {
                    left_indicators[i].GetComponent<SpriteRenderer>().enabled = false;
                    right_indicators[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }

        }

        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        {
            foreach (MenuItem item in items)
            {
                if (item.activated)
                {
                    ind_index = item.index;
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == ind_index)
                        {
                            left_indicators[i].GetComponent<SpriteRenderer>().enabled = true;
                            right_indicators[i].GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else
                        {
                            left_indicators[i].GetComponent<SpriteRenderer>().enabled = false;
                            right_indicators[i].GetComponent<SpriteRenderer>().enabled = false;
                        }
                    }
                }
            }
        }

    }
}
