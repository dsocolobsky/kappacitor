using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    // Velocidad a la que se mueve la bala
    public float speed = 5.0f;
    // Posicion actual del mouse (donde va a ir la bala)
    Vector3 mousePosition;
    // Vector de direccion para la bala
    Vector3 direction;
    
    // Si vamos a destruir o no la bala (en colision)
    bool doDestroy = false;
    // Timer que mida el tiempo que tarda en destruirse la bala tras una colision
    float destroyTime = 0.0f;

    // Sprite que va a tener la bala una vez que explote
    public Sprite exploded;

    public float removeTime = 5.0f;
    float removeTimer = 0.0f;

    public AudioClip hitSound;
    new AudioSource audio;

    void Start()
    {
        // Obtener la posicion del mouse
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        // Crear nuestro vector direccion dada la posicion del mouse y del arma
        direction = (mousePosition - transform.position).normalized;

        audio = GetComponent<AudioSource>();
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
        doDestroy = true;
        GetComponent<SpriteRenderer>().sprite = exploded;
        audio.Play(0);
    }
}