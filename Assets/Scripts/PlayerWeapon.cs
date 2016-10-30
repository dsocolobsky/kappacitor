using UnityEngine;

public class PlayerWeapon : Shooting {

    public GameObject cargadorObject;
    Cargador cargador;

    public float reloadTime;
    float reloadTimer = 0.0f;

    bool recargando = false;

    AudioSource audioSource;

    Player player;

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

        player = GetComponentInParent<Player>();
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
                player.ShowCargadorHud(false);
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.R) && !recargando && cargador.actualBalas < 6) ||
            cargador.actualBalas < 1)
        {
            recargando = true;
            player.ShowCargadorHud(true);
        }

        if (cargador.actualBalas < 1)
        {
            recargando = true;
        }
    }
}
