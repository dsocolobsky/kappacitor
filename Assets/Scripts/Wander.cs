using UnityEngine;
using System.Collections;

public class Wander : MonoBehaviour
{
    public Vector3 target { get; private set; }
    Vector3 anchor;
    public float circleRadius;

    GameObject player;

    public bool detectedPlayer { get; private set; }
    public float speed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anchor = transform.position;
        detectedPlayer = false;
        target = newTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectedPlayer)
        {
            target = player.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            target = newTarget();
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        detectedPlayer = hit.collider.tag == "Player";
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(anchor, circleRadius);
        Gizmos.color = new Color(0, 0, 1, 0.25f);
        Gizmos.DrawSphere(anchor, circleRadius * 0.05f);
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawSphere(target, circleRadius * 0.05f);
        Gizmos.color = detectedPlayer ? Color.red : Color.cyan;

        if (player)
            Gizmos.DrawRay(transform.position, player.transform.position - transform.position);
    }

    Vector3 newTarget()
    {
        Vector3 target = new Vector3();
        target = Random.insideUnitCircle * circleRadius + new Vector2(anchor.x, anchor.y);

        return target;
    }

    public Vector3 newDirection()
    {
        Vector3 retdir = new Vector3();
        Vector3 direction = target - transform.position;

        if (direction.x > -0.75f && direction.x < 0.75f)
        {
            retdir.x = 0;
        }
        else if (direction.x < -0.75f)
        {
            retdir.x = -1;
        }
        else {
            retdir.x = 1;
        }

        if (direction.y < 0)
        {
            retdir.y = -1;
        }
        else if (direction.y > 0)
        {
            retdir.y = 1;
        }

        return retdir;
    }

}
