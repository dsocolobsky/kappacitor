using UnityEngine;

// Este es el script que hace girar el arma dependiendo
// donde se encuentra el mouse
public class FlipShield : MonoBehaviour
{
    Vector3 mousePos; // Posicion del mouse

    public float topMin = 45f;
    public float topMax = 135f;
    public float newPosX = 0.018f;

    bool atBackground = false;

    // Use this for initialization
    void Start()
    {
        mousePos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = getAngle();

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        bool isUp = angle > topMin && angle < topMax;

        if (!atBackground && isUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            atBackground = true;
        }
        else if (atBackground && !isUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            atBackground = false;
        }
    }

    // Esta funcion devuelve el angulo que hay entre el arma y la posicion
    // del mouse
    float getAngle()
    {
        mousePos = Input.mousePosition;
        Vector2 distance = mousePos - Camera.main.WorldToScreenPoint(transform.position);
        return Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
    }

}
