using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunTip;
    public float fireRate = 0.0f;

    float timeToFire = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);
    }
}
