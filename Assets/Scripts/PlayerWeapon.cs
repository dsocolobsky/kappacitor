using UnityEngine;

public class PlayerWeapon : Shooting {

    public GameObject cargadorObject;
    Cargador cargador;

    public float reloadTime;
    float reloadTimer = 0.0f;

	// Use this for initialization
	void Start () {
        if (cargadorObject != null)
        {
            cargador = cargadorObject.GetComponent<Cargador>();
        }
	}

    public new bool Shoot()
    {
        if (Time.time < timeToFire || cargador.actualBalas < 1)
            return false;

        timeToFire = Time.time + 1 / fireRate;
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);

        if (audio)
        {
            audio.Play();
        }

        cargador.GastarBala();
        return true;
    }

    // Update is called once per frame
    void Update () {
        if (cargador.actualBalas < 1)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer > reloadTime)
            {
                cargador.Reload();
                reloadTimer = 0.0f;
            }
        }
    }
}
