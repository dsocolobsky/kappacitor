using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMenu : MonoBehaviour
{

    int ind_index = 0;
    GameObject[] left_indicators;
    GameObject[] right_indicators;
    GameObject[] barritas;

    // Use this for initialization
    void Start()
    {
        left_indicators = new GameObject[4];
        right_indicators = new GameObject[4];

        for (int i = 0; i <= 3; i++)
        {
            left_indicators[i] = GameObject.Find("ind_left_" + i.ToString());
            right_indicators[i] = GameObject.Find("ind_right_" + i.ToString());
        }

        barritas = new GameObject[3];
        barritas[0] = GameObject.Find("barritasonido_0");
        barritas[1] = GameObject.Find("barritasonido_1");
        barritas[2] = GameObject.Find("barritasonido_2");

        ind_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && ind_index == 3)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && ind_index != 3)
        {
            Vector3 scale = barritas[ind_index].transform.localScale;
            if (scale.x > 0.0f)
            {
                float scalex = scale.x - 0.10f;
                barritas[ind_index].transform.localScale = new Vector3(scalex, scale.y, scale.z);
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && ind_index != 3)
        {
            Vector3 scale = barritas[ind_index].transform.localScale;
            if (scale.x < 1.0f)
            {
                float scalex = scale.x + 0.10f;
                barritas[ind_index].transform.localScale = new Vector3(scalex, scale.y, scale.z);
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
