using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class JuegoMenu : MonoBehaviour {

    GameObject[] miras;
    int selected_mira = 0;

	// Use this for initialization
	void Start () {
        miras = new GameObject[7];
        for (int i = 0; i <= 7; i++)
        {
            miras[i] = GameObject.Find("mira_" + i.ToString());
        }

        int actualMira = int.Parse(PlayerPrefs.GetString("mira", "0"));
        selected_mira = actualMira;
        miras[actualMira].GetComponent<MiraDeMenu>().Select();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            Salir();
        }
    }

    public void SelectedMira(int index)
    {
        foreach (GameObject mira in miras)
        {
            MiraDeMenu script = mira.GetComponent<MiraDeMenu>();
            if (script.index != index)
            {
                script.Deselect();
            }
        }

        selected_mira = index + 1;
    }

    public void Salir()
    {
        PlayerPrefs.SetString("mira", selected_mira.ToString());
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
