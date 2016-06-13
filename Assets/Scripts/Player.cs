using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    ChangePlayerAnimation changeAnimation;
    public GameObject lifebarObject;
    Lifebar lifebar;
    Shooting gunScript;
    DashAbility dash;
    public float speed;
    public int hitpoints = 6;

    // Use this for initialization
    void Start()
    {
        changeAnimation = GetComponent<ChangePlayerAnimation>();
        lifebar = lifebarObject.GetComponent<Lifebar>();
        gunScript = transform.Find("gun").gameObject.GetComponent<Shooting>();
        dash = GetComponent<DashAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetButton("Fire1") && !dash.dashing())
        {
            gunScript.Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemybullet" && !dash.dashing())
        {
            GetComponent<TurnRed>().Execute();

            hitpoints--;
            lifebar.Change(hitpoints);

			if (hitpoints <= 0) {
				Text score = GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ();
                PlayerPrefs.SetString("score", score.text);

                SceneManager.LoadScene ("Scenes/dead");
			}
        }
    }
}
