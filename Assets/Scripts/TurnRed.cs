using UnityEngine;
using System.Collections;

public class TurnRed : MonoBehaviour {

    public float time = 0.2f;

    bool isRed = false;
    float timer = 0.0f;
    Color original;
    Color red;

	// Use this for initialization
	void Start () {
        original = new Color(1.0f, 1.0f, 1.0f);
        red = new Color(1.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isRed)
        {
            timer += Time.deltaTime;

            if (timer > time)
            {
                transform.gameObject.GetComponent<SpriteRenderer>().color = original;
                isRed = false;
                timer = 0.0f;
            }
        }
	}

    public void Execute()
    {
        if (!isRed)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = red;
            isRed = true;
        }
    }
}
