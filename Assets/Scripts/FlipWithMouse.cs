using UnityEngine;

public class FlipWithMouse : MonoBehaviour
{

    bool flipped;
    Vector3 mousePos;

    // Use this for initialization
    void Start()
    {
        mousePos = new Vector3();
        flipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Vector2 distance = mousePos - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (!isFacingRight(angle) && !flipped)
        {
            flip();
        }
        else if (isFacingRight(angle) && flipped)
        {
            flip();
        }
    }

    void flip()
    {
        Vector3 position = transform.localPosition;

        if (!flipped)
        {
            position.x = 0.0f;
        }
        else
        {
            position.x = 0.1f;
        }
        transform.localPosition = position;

        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;

        flipped = !flipped;
    }

    bool isFacingRight(float angle)
    {
        if ((angle > 90 && angle < 180) || (angle < -90 && angle > -180))
        {
            return false;
        }

        return true;
    }
}
