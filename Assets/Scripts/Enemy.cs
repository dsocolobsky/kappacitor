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
    public float speed = 0.75f;

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

    // Use this for initialization
    void Start()
    {
        changeAnimation = GetComponent<ChangeEnemyAnimation>();
        wander = GetComponent<Wander>();
		score = GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ();
        attackCooldown = Mathf.FloorToInt(Random.Range(2, 6));
        attackingTime = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener una nueva direccion para hacer roaming
        Vector3 direction = wander.newDirection();

        // TODO: Implementar logica de ataque
        if (state == State.DYING)
        {
            speed = 0.0f;
            changeAnimation.changeState(state);
            changeAnimation.Change(direction.x, direction.y);

            deathTimer += Time.deltaTime;
            if (deathTimer > deathTime)
            {
                Destroy(this.gameObject);
            }
        }
        

        if (state == State.MOVING)
        {
            // Reiniciar velocidad
            speed = 0.75f;

            changeAnimation.changeState(state);
            changeAnimation.Change(direction.x, direction.y);

            if (wander.detectedPlayer && !onCooldown)
            {
                float distance = Vector3.Distance(wander.target, transform.position);
                if (distance < 4)
                {
                    attack();
                }
            }
        }

        if (state == State.ATTACKING)
        {
            changeAnimation.changeState(state);
            changeAnimation.Change(direction.x, direction.y);

            attackingTimer += Time.deltaTime;

            if (attackingTimer >= attackingTime)
            {
                deattack();
                changeAnimation.changeState(state);
                changeAnimation.Change(direction.x, direction.y);
                attackingTimer = 0.0f;
                attackCooldown = Mathf.FloorToInt(Random.Range(2, 6));
                attackingTime = Random.Range(2, 6);
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

        wander.speed = speed;
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
                state = State.DYING;
                changeAnimation.changeState(this.state);
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
	}

    void attack()
    {
        speed = 0.0f;
        state = State.ATTACKING;
    }

    void deattack()
    {
        speed = 0.75f;
        state = State.MOVING;
        onCooldown = true;
    }
}
