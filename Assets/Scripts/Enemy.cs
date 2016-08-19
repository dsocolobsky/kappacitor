using UnityEngine;
using UnityEngine.UI;

// Script del enemigo (capacitor por ahora) que se ocupa
// de varias tareas
public class Enemy : MonoBehaviour
{
    public enum State
    {
        MOVING,
        ATTACKING,
        DYING
    }

    public State state = State.MOVING;

    // Vida del enemigo
    public int hitponts = 3;
    // Velocidad del enemigo
    public float speed = 0.35f;

    Text score;

    // Script que cambia la animacion segun su direccion
    ChangeEnemyAnimation changeAnimation;
    // Script que controla la IA del enemigo
    Wander wander;

    float deathTime = 1.0f;
    float deathTimer = 0.0f;

    float attackCooldown = 3.0f;
    float attackCooldownTimer = 0.0f;

    bool onCooldown = false;
    float attackingTime = 2.0f;
    float attackingTimer = 0.0f;

    Vector3 direction;

    //public GameObject despawn;

    // Use this for initialization
    void Start()
    {
        changeAnimation = GetComponent<ChangeEnemyAnimation>();
        wander = GetComponent<Wander>();
        score = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        direction = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener una nueva direccion para hacer roaming
        direction = wander.newDirection();

        if (state == State.MOVING)
        {
            if (wander.detectedPlayer && !onCooldown)
            {
                float distance = Vector3.Distance(wander.target, transform.position);
                if (distance < 4)
                {
                    changeState(State.ATTACKING);
                }
            }
        }

        if (state == State.ATTACKING)
        {
            attackingTimer += Time.deltaTime;

            if (attackingTimer >= attackingTime)
            {
                changeState(State.MOVING);
            }
        }

        if (state == State.DYING)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > deathTime)
            {
                Destroy(this.gameObject);
            }
        }

        if (state != State.DYING && onCooldown)
        {
            attackCooldownTimer += Time.deltaTime;
            if (attackCooldownTimer >= attackCooldown)
            {
                attackCooldownTimer = 0.0f;
                onCooldown = false;
            }
        }

        wander.speed = speed;
        changeAnimation.Change(direction.x, direction.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Si una bala colisiona con el enemigo
        if (col.gameObject.name.StartsWith("bullet") && state != State.DYING)
        {
            GetComponent<TurnRed>().Execute();

            // Decremetar la vida por uno
            hitponts--;

            // Comprobar si el capacitor murio
            if (hitponts <= 0)
            {
                changeState(State.DYING);
            }
        }
    }

    void OnDestroy()
    {
        if (score)
        {
            int intscore = int.Parse(score.text);
            intscore += 100;
            score.text = intscore.ToString();
        }

        //Instantiate(despawn, transform.position, Quaternion.identity);
        transform.gameObject.GetComponent<DropItem>().Drop();
    }

    void changeState(State state)
    {
        this.state = state;

        switch (state)
        {
            case State.MOVING:
                speed = 0.35f;
                onCooldown = true;
                break;
            case State.ATTACKING:
                speed = 0.00f;
                attackCooldown = 3.0f;
                attackingTime = 2.0f;
                attackingTimer = 0.0f;
                break;
            case State.DYING:
                speed = 0.00f;
                break;
        }

        changeAnimation.changeState(state);
        changeAnimation.Change(direction.x, direction.y);
    }

}
