using UnityEngine;
using System.Collections;

public class ShieldPulse : MonoBehaviour {

    public float time = 0.2f;

    bool isHit = false;
    float timer = 0.0f;
    Color original;
    Color pulse;

    SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();

        original = new Color(0.8f, 0.8f, 0.8f);
        pulse = new Color(1.0f, 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isHit)
        {
            timer += Time.deltaTime;

            if (timer > time)
            {
                sprite.color = original;
                isHit = false;
                timer = 0.0f;
            }
        }
	}

    public void Execute()
    {
        if (!isHit)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().color = pulse;
            isHit = true;
        }
    }
}
