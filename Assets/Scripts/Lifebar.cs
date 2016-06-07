using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    GameObject first;
    GameObject second;
    GameObject third;

    public Sprite empty;

    public Sprite green_full;
    public Sprite green_half;

    public Sprite yellow_full;
    public Sprite yellow_half;

    public Sprite red_full;
    public Sprite red_half;

    // Use this for initialization
    void Start()
    {
        first = transform.Find("first").gameObject;
        second = transform.Find("second").gameObject;
        third = transform.Find("third").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change(int hitpoints)
    {

        switch (hitpoints)
        {
            case 6:
                first.GetComponent<Image>().sprite = green_full;
                second.GetComponent<Image>().sprite = green_full;
                third.GetComponent<Image>().sprite = green_full;
                break;
            case 5:
                first.GetComponent<Image>().sprite = green_full;
                second.GetComponent<Image>().sprite = green_full;
                third.GetComponent<Image>().sprite = green_half;
                break;
            case 4:
                first.GetComponent<Image>().sprite = yellow_full;
                second.GetComponent<Image>().sprite = yellow_full;
                third.GetComponent<Image>().sprite = empty;
                break;
            case 3:
                first.GetComponent<Image>().sprite = yellow_full;
                second.GetComponent<Image>().sprite = yellow_half;
                third.GetComponent<Image>().sprite = empty;
                break;
            case 2:
                first.GetComponent<Image>().sprite = red_full;
                second.GetComponent<Image>().sprite = empty;
                third.GetComponent<Image>().sprite = empty;
                break;
            case 1:
                first.GetComponent<Image>().sprite = red_half;
                second.GetComponent<Image>().sprite = empty;
                third.GetComponent<Image>().sprite = empty;
                break;
            default:
                first.GetComponent<Image>().sprite = empty;
                second.GetComponent<Image>().sprite = empty;
                third.GetComponent<Image>().sprite = empty;
                break;
        }
    }
}
