using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    int ind_index = 0;
    GameObject[] left_indicators;
    GameObject[] right_indicators;

	// Use this for initialization
	void Start () {
        left_indicators = new GameObject[4];
        right_indicators = new GameObject[4];

        for (int i = 0; i <= 3; i++)
        {
            left_indicators[i] = GameObject.Find("ind_left_" + i.ToString());
            right_indicators[i] = GameObject.Find("ind_right_" + i.ToString());
        }

        ind_index = 0;

        if (!PlayerPrefs.HasKey("total_volume"))
        {
            PlayerPrefs.SetFloat("total_volume", 1.0f);
            PlayerPrefs.SetFloat("sound_volume", 1.0f);
            PlayerPrefs.SetFloat("music_volume", 1.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
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

	}
}
