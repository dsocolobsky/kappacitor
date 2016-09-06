using UnityEngine;
using System.Collections;

public class Led : MonoBehaviour
{
    public enum State
    {
        MOVING,
        ATTACKING,
        EXPLODING
    }

    public State state = State.MOVING;

    GameObject player;
    bool detectedPlayer;

    public float speed;

    ChangeLedAnimation changeAnimation;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detectedPlayer = false;
        changeAnimation = GetComponent<ChangeLedAnimation>();
    }

    void FixedUpdate()
    {
        if (!player) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        detectedPlayer = hit.collider.tag == "Player";
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.MOVING)
        {
            this.speed = 0.0f;
        }

        if (detectedPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        // TODO: Explotar
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 0.2f && state == State.MOVING)
        {
            state = State.ATTACKING;
        }

        Vector3 direction = getDirection();
        changeAnimation.Change(state, direction.x, direction.y);
    }

    public Vector3 getDirection()
    {
        Vector3 retdir = new Vector3();
        Vector3 direction = player.transform.position - transform.position;

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

    public void ChangeState(State state)
    {
        this.state = state;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
