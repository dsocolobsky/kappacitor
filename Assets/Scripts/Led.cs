using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Led : MonoBehaviour
{
    Text score;

    public enum State
    {
        MOVING,
        ATTACKING,
    }

    public State state = State.MOVING;

    GameObject player;
    bool detectedPlayer;
    bool touchingPlayer = false;

    public float speed;

    ChangeLedAnimation changeAnimation;

    public int hitpoints = 2;

    public float circleRadius;
    Vector3 target;
    bool goStraight = false;
    bool separating = false;
    float separateTimer = 0.0f;

    BoxCollider2D[] colliders;

    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detectedPlayer = false;
        changeAnimation = GetComponent<ChangeLedAnimation>();
        target = new Vector3();
        score = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (!player) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);

        if (!detectedPlayer && hit && !goStraight)
            target = newTarget();

        detectedPlayer = hit.collider.tag == "Player";

        if (!hit && detectedPlayer)
            detectedPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.MOVING)
        {
            speed = 0.0f;
        }

        if (detectedPlayer && target != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (transform.position == target && !separating)
        {
            target = player.transform.position;
            goStraight = true;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.StartsWith("bullet"))
        {
            GetComponent<TurnRed>().Execute();
            hitpoints--;
            if (hitpoints <= 0) Explode();
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if ((col.gameObject.name.StartsWith("led") || col.gameObject.name.StartsWith("wall")))
        {
            separateTimer += Time.deltaTime;
            if (separateTimer > 1.0f)
            {
                target = newSeparateTarget();
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        //Gizmos.DrawSphere(player.transform.position, circleRadius);
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawSphere(target, circleRadius * 0.05f);
        Gizmos.color = detectedPlayer ? Color.red : Color.cyan;

        if (player)
            Gizmos.DrawRay(transform.position, player.transform.position - transform.position);
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

    Vector3 newTarget()
    {
        Vector3 target = new Vector3();
        target = Random.insideUnitCircle * circleRadius + new Vector2(player.transform.position.x, player.transform.position.y);

        return target;
    }

    Vector3 newSeparateTarget()
    {
        Vector3 target = new Vector3();
        target = Random.insideUnitCircle * circleRadius/2 + new Vector2(transform.position.x, transform.position.y);

        return target;
    }

    public void ChangeState(State state)
    {
        this.state = state;
    }

    public void Explode()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity);

        if (score)
        {
            int intscore = int.Parse(score.text);
            intscore += 100;
            score.text = intscore.ToString();
        }

        Destroy(this.gameObject);
    }
}
