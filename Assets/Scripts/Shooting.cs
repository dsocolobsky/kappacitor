using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunTip;
    public float fireRate = 0.0f;

    float timeToFire = 0.0f;

    public bool isEnemy;

    // Use this for initialization
    void Start()
    {
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
    }

    public void ShootAtPlayer()
    {
        if (Time.time < timeToFire)
            return;

        timeToFire = Time.time + 1 / fireRate;
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);
    }
}
