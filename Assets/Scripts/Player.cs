using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    ChangePlayerAnimation changeAnimation;
    public GameObject lifebarObject;
    Lifebar lifebar;
    Shooting gunScript;

    public float speed;
    public int hitpoints = 6;

    // Use this for initialization
    void Start()
    {
        changeAnimation = GetComponent<ChangePlayerAnimation>();
        lifebar = lifebarObject.GetComponent<Lifebar>();
        gunScript = transform.Find("gun").gameObject.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            gunScript.Shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemybullet")
        {
            hitpoints--;
            lifebar.Change(hitpoints);
        }
    }
}
