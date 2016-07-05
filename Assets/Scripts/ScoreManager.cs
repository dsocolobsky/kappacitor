using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Text scoreText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        string score = PlayerPrefs.GetString("score");

        scoreText.text = "High Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Scenes/level1");
        }
    }
}
