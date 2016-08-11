using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunTip;
    public float fireRate = 0.0f;

    float timeToFire = 0.0f;

    public bool isEnemy;

    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = transform.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (Time.time < timeToFire)
            return;

        timeToFire = Time.time + 1 / fireRate;
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);

        if (audio)
        {
            audio.Play();
        }

        //gameObject.GetComponent<Animator>().SetBool("shooting", true);
    }

    public void ShootAtPlayer()
    {
        if (Time.time < timeToFire)
            return;

        timeToFire = Time.time + 1 / fireRate;
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);

        if (audio)
        {
            audio.Play();
        }
    }

    public void setShootingFalse()
    {
        gameObject.GetComponent<Animator>().SetBool("shooting", false);
    }
}
