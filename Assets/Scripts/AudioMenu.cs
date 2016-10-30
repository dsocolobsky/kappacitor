using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMenu : MonoBehaviour
{
    int ind_index = 0;
    GameObject[] left_indicators;
    GameObject[] right_indicators;
    GameObject[] barritas;
    MenuItem[] items;

    float music_volume;
    float sound_volume;

    SoundManager soundmanager;

    // Use this for initialization
    void Start()
    {
        items = new MenuItem[3];
        items[0] = GameObject.Find("musica").GetComponent<MenuItem>();
        items[1] = GameObject.Find("efectos").GetComponent<MenuItem>();
        items[2] = GameObject.Find("atras").GetComponent<MenuItem>();

        left_indicators = new GameObject[3];
        right_indicators = new GameObject[3];

        for (int i = 0; i <= 2; i++)
        {
            left_indicators[i] = GameObject.Find("ind_left_" + i.ToString());
            right_indicators[i] = GameObject.Find("ind_right_" + i.ToString());
        }

        barritas = new GameObject[3];
        barritas[0] = GameObject.Find("barritasonido_0");
        barritas[1] = GameObject.Find("barritasonido_1");

        ind_index = 0;

        music_volume = PlayerPrefs.GetFloat("music_volume");
        sound_volume = PlayerPrefs.GetFloat("sound_volume");

        setBarritaScale(0, music_volume);
        setBarritaScale(1, sound_volume);

        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0)) && ind_index == 2)
        {
            soundmanager.Selected();

            music_volume = sanitize(barritas[0].transform.localScale.x);
            sound_volume = sanitize(barritas[1].transform.localScale.x);

            PlayerPrefs.SetFloat("sound_volume", sound_volume);
            PlayerPrefs.SetFloat("music_volume", music_volume);

            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && ind_index != 2)
        {
            if (ind_index == 0)
            {
                changeVolume(0, -1, ref sound_volume);
            } else if(ind_index == 1)
            {
                changeVolume(1, -1, ref music_volume);
            }
        } else if (Input.GetKeyUp(KeyCode.RightArrow) && ind_index != 2)
        {
            if (ind_index == 0)
            {
                changeVolume(0, 1, ref sound_volume);
            } else if (ind_index == 1)
            {
                changeVolume(1, 1, ref music_volume);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                ind_index++;
                if (ind_index > 2)
                    ind_index = 2;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                ind_index--;
                if (ind_index < 0)
                    ind_index = 0;
            }

            for (int i = 0; i <= 2; i++)
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

            soundmanager.MouseOver();
        }

        if (Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0)
        {
            foreach (MenuItem item in items)
            {
                if (item.activated)
                {
                    if (ind_index != item.index) soundmanager.MouseOver();

                    ind_index = item.index;
                    for (int i = 0; i <= 2; i++)
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

    public void clickedBarrita(int index, int direction)
    {
        if (index == 0)
        {
            changeVolume(0, direction, ref music_volume);
        }
        else
        {
            changeVolume(1, direction, ref sound_volume);
        }
    }

    void setBarritaScale(int index, float volume)
    {
        Vector3 localscale = barritas[index].transform.localScale;
        barritas[index].transform.localScale = new Vector3(volume, localscale.y, localscale.z);
    }

    void changeVolume(int index, int direction, ref float volume)
    {
        Vector3 scale = barritas[index].transform.localScale;
        if (direction == -1 && scale.x > 0.0f)
        {
            float scalex = scale.x - 0.10f;
            barritas[index].transform.localScale = new Vector3(scalex, scale.y, scale.z);
            volume = scalex;
        } else if (direction == 1 && scale.x < 1.0f)
        {
            float scalex = scale.x + 0.10f;
            barritas[index].transform.localScale = new Vector3(scalex, scale.y, scale.z);
            volume = scalex;
        }
    }

    float sanitize(float n)
    {
        float m = (float)System.Math.Round(n, 2);
        if (m < 0)
        {
            m = 0;
        }
        else if (m > 1)
        {
            m = 1;
        }

        return m;
    }

}
