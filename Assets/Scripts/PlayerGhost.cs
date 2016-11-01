using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerGhost : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate(int enemy)
    {
        Text score = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        PlayerPrefs.SetString("score", score.text);
        int scoren = int.Parse(score.text);

        if (PlayerPrefs.GetInt("highscore", 0) < scoren)
        {
            PlayerPrefs.SetInt("highscore", scoren);
        }

        PlayerPrefs.SetInt("deadby", enemy);
    }

    public void Destroy()
    {
        SceneManager.LoadScene("Scenes/dead");
    }
}
