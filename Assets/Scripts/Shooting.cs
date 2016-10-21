using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunTip;
    public float fireRate = 0.0f;

    protected float timeToFire = 0.0f;

    public bool isEnemy;

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.volume = PlayerPrefs.GetFloat("sound_volume");
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

        if (audioSource)
        {
            audioSource.Play();
        }
    }

    public void ShootAtPlayer()
    {
        if (Time.time < timeToFire)
            return;

        timeToFire = Time.time + 1 / fireRate;
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);

        if (audioSource)
        {
            audioSource.Play();
        }
    }

    public void setShootingFalse()
    {
        gameObject.GetComponent<Animator>().SetBool("shooting", false);
    }
}
