using UnityEngine;

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

    // El enemigo esta en rojo? (atacado)
    bool isRed = false;
    // Timer para controlar cuanto tiempo esta en rojo
    float timeRed = 0.0f;

    // Vida del enemigo
    public int hitponts = 3;
    // Velocidad del enemigo
    public float speed = 0.75f;

    // Script que cambia la animacion segun su direccion
    ChangeEnemyAnimation changeAnimation;
    // Script que controla la IA del enemigo
    Wander wander;

    float deathTime = 1.0f;
    float deathTimer = 0.0f;

    float attackCooldown = 2.0f;
    float attackCooldownTimer = 0.0f;

    bool onCooldown = false;
    float attackingTime = 2.0f;
    float attackingTimer = 0.0f;

    // Use this for initialization
    void Start()
    {
        changeAnimation = GetComponent<ChangeEnemyAnimation>();
        wander = GetComponent<Wander>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reiniciar velocidad
        speed = 0.75f;

        if (!isRed)
        {
            timeRed++;
        }

        // Mantener al enemigo en rojo solo durante 10 frames
        if (timeRed > 10)
        {
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            isRed = false;
            timeRed = 0.0f;
        }

        // TODO: Implementar logica de ataque
        if (state == State.DYING)
        {
            speed = 0.0f;

            deathTimer += Time.deltaTime;
            if (deathTimer > deathTime)
            {
                Destroy(this.gameObject);
            }
        }
        // Obtener una nueva direccion para hacer roaming
        Vector3 direction = wander.newDirection();
        // Cambiar la animacion dependiendo de la direccion
        changeAnimation.Change(direction.x, direction.y);

        // TODO: Implementar logica de ataque
        if (state != State.ATTACKING && wander.detectedPlayer && !onCooldown)
        {
            float distance = Vector3.Distance(wander.target, transform.position);
            if (distance < 4)
            {
                attack();
            }
        }

        if (state == State.ATTACKING)
        {
            attackingTimer += Time.deltaTime;

            if (attackingTimer >= attackingTime)
            {
                deattack();
            }
        }

        if (onCooldown)
        {
            attackCooldownTimer += Time.deltaTime;
            if (attackCooldownTimer >= attackCooldown)
            {
                attackCooldownTimer = 0.0f;
                onCooldown = false;
            }
        }

        //Debug.Log(attackCooldownTimer);
        wander.speed = speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Si una bala colisiona con el enemigo
        if (col.gameObject.name.StartsWith("bullet"))
        {
            // Si no esta en rojo, ponerlo en rojo
            if (!isRed)
            {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f);
            }

            // Decremetar la vida por uno
            hitponts--;

            // Comprobar si el capacitor murio
            if (hitponts <= 0)
            {
                state = State.DYING;
                changeAnimation.changeState(this.state);
            }
        }
    }

    void attack()
    {
        speed = 0.0f;
        state = State.ATTACKING;
        changeAnimation.changeState(State.ATTACKING);
    }

    void deattack()
    {
        speed = 0.75f;
        state = State.MOVING;
        changeAnimation.changeState(State.MOVING);
        onCooldown = true;
    }
}
