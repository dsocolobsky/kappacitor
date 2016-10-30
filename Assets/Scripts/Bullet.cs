using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Velocidad a la que se mueve la bala
    public float speed = 5f;
    // Vector de direccion para la bala
    protected Vector3 direction;
    protected Vector3 screenPoint;

    // Si vamos a destruir o no la bala (en colision)
    protected bool doDestroy = false;
    // Timer que mida el tiempo que tarda en destruirse la bala tras una colision
    float destroyTime = 0.0f;

    // Sprite que va a tener la bala una vez que explote
    public Sprite exploded;

    public float removeTime = 5.0f;
    float removeTimer = 0.0f;

    public AudioClip hitSound;
    protected AudioSource audioSource;

    void Start()
    {
        // Crear nuestro vector direccion dada la posicion del mouse y del arma
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        direction = (Input.mousePosition - screenPoint).normalized;
        direction.z = 0;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = hitSound;
        audioSource.volume = PlayerPrefs.GetFloat("sound_volume");
    }

    void Update()
    {
        // Si vamos a destruir la bala
        if (doDestroy)
        {
            // Aumentar el contador
            destroyTime += 1.0f;

            // Si ya es hora de destruir la bala, destruirla y reiniciar todo
            if (destroyTime > 4.0f)
            {
                Destroy(this.gameObject);
                doDestroy = false;
                destroyTime = 0.0f;
            }
        }
        else {
            // Sino, mover la bala
            transform.position += direction * speed * Time.deltaTime;
        }

        removeTimer += Time.deltaTime;
        if (removeTimer > removeTime)
        {
            Destroy(this.gameObject);
        }
    }

    // Si la bala colisiona con algo, comenzar a destruirla
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            audioSource.Play();
        }

        if (col.gameObject.tag != "drop" && col.gameObject.tag != "explosion")
        {
            doDestroy = true;
            GetComponent<SpriteRenderer>().sprite = exploded;
        }
    }
}