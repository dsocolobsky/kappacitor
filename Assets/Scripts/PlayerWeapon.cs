using UnityEngine;

public class PlayerWeapon : Shooting {

    public GameObject cargadorObject;
    Cargador cargador;

    public float reloadTime;
    float reloadTimer = 0.0f;

    bool recargando = false;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        if (cargadorObject != null)
        {
            cargador = cargadorObject.GetComponent<Cargador>();
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.volume = PlayerPrefs.GetFloat("sound_volume");
        }
	}

    public new bool Shoot()
    {
        if (Time.time < timeToFire || cargador.actualBalas < 1)
            return false;

        timeToFire = Time.time + 1 / fireRate;
        Instantiate(bullet, gunTip.transform.position, Quaternion.identity);

        if (audioSource)
        {
            audioSource.Play();
        }

        cargador.GastarBala();
        return true;
    }

    // Update is called once per frame
    void Update () {
        if (recargando)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer > reloadTime)
            {
                cargador.Reload();
                reloadTimer = 0.0f;
                recargando = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R) && !recargando && cargador.actualBalas < 6)
        {
            recargando = true;
        }

        if (cargador.actualBalas < 1)
        {
            recargando = true;    
        }
    }
}
