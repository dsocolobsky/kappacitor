using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 mousePosition;
    Vector3 direction;

    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        direction = (mousePosition - transform.position).normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}