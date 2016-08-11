using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject lifebarObject;
    Lifebar lifebar;
    Shooting gunScript;

    public float speed;
    float savedSpeed;
    public int hitpoints = 6;

    public AudioClip minimize;
    public AudioClip maximize;

    new CameraScript camera;

    Animator animator;
    string previousAnimation;

    float horizontal = 0.0f;
    float vertical = 0.0f;

    public enum State
    {
        Idle,
        Moving,
        Dashing
    }

    public enum DashState
    {
        Ready,
        Minimizing,
        Dashing,
        Maximizing,
        Cooldown
    }

    public State state = State.Idle;
    public DashState dashState = DashState.Ready;

    float topLeftMin = 112f;
    float topLeftMax = 157f;

    float topMin = 67f;
    float topMax = 112f;

    float topRightMin = 22f;
    float topRightMax = 67f;

    float rightMin = -67f;
    float rightMax = 22f;

    float botMin = -67f;
    float botMax = -112f;

    float leftMin = -112f;
    float leftMax = 157f;

    public float dashCooldown = 6.0f;
    float dashCooldownTimer = 0.0f;

    // Use this for initialization
    void Start()
    {
        lifebar = lifebarObject.GetComponent<Lifebar>();
        gunScript = transform.Find("gun").gameObject.GetComponent<Shooting>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>();
        animator = GetComponent<Animator>();
        previousAnimation = "player_idle";
        savedSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!reallyDashing())
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            calculateAngle();
        }

        Vector3 move = new Vector3(horizontal, vertical, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetButton("Fire1") && !reallyDashing())
        {
            gunScript.Shoot();
            camera.StartShaking();
        }

        switch (dashState)
        {
            case DashState.Ready:
                bool isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    switchDashState(DashState.Minimizing);
                }
                break;
            case DashState.Cooldown:
                dashCooldownTimer += Time.deltaTime;
                if (dashCooldownTimer >= dashCooldown)
                {
                    switchDashState(DashState.Ready);
                }
                break;
        }
    }

    public void switchDashState(DashState state)
    {
        switch (state)
        {
            case DashState.Ready:
                dashCooldownTimer = 0.0f;
                break;
            case DashState.Minimizing:
                speed = 0.0f;
                playSound(minimize);
                switchState(State.Dashing);
                break;
            case DashState.Dashing:
                speed = savedSpeed * 3f;
                break;
            case DashState.Maximizing:
                speed = 0.0f;
                playSound(maximize);
                break;
            case DashState.Cooldown:
                speed = savedSpeed;
                switchState(State.Idle);
                break;
        }

        dashState = state;
    }

    public void switchState(State state)
    {
        switch (state)
        {
            case State.Dashing:
                gunScript.GetComponentInParent<SpriteRenderer>().enabled = false;
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = Input.GetAxisRaw("Vertical");
                calculateAngle();
                break;
            case State.Idle:
            case State.Moving:
                gunScript.GetComponentInParent<SpriteRenderer>().enabled = true;
                break;
        }

        this.state = state;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemybullet" && !reallyDashing())
        {
            GetComponent<TurnRed>().Execute();

            hitpoints--;
            lifebar.Change(hitpoints);

			if (hitpoints <= 0) {
				Text score = GameObject.FindGameObjectWithTag ("score").GetComponent<Text> ();
                PlayerPrefs.SetString("score", score.text);

                SceneManager.LoadScene ("Scenes/dead");
			}
        }

        if (col.gameObject.tag == "wall" && reallyDashing())
        {
            switchDashState(DashState.Cooldown);
        }
    }

    public bool addHitpoints(int toAdd)
    {
        switch (hitpoints)
        {
            case 6:
                return false;
            case 5:
                hitpoints += 1;
                break;
            default:
                hitpoints += toAdd;
                break;
        }

        lifebar.Change(hitpoints);
        return true;
    }

    public void playSound(AudioClip clip)
    {
        transform.gameObject.GetComponent<AudioSource>().clip = clip;
        transform.gameObject.GetComponent<AudioSource>().Play();
    }

    void playAnimation(string anim)
    {
        if (state == State.Dashing)
            animator.Play("player_dash_" + anim);
        else if (state == State.Moving)
            animator.Play("player_" + anim);
        else
            animator.Play("player_idle_" + anim);

        previousAnimation = anim;
    }

    // Devuelve el angulo que hay desde el jugador hasta la posicion del mouse
    float getAngle()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 distance = mousePos - Camera.main.WorldToScreenPoint(transform.position);
        return Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
    }

    public void calculateAngle()
    {
        float angle = getAngle();

        bool isUp = angle > topMin && angle < topMax;
        bool isDown = angle < botMin && angle > botMax;
        bool isLeft = angle > 157 || angle < -112f;
        bool isRight = angle > rightMin && angle < rightMax;
        bool isTopLeft = angle > topLeftMin && angle < topLeftMax;
        bool isTopRight = angle > topRightMin && angle < topRightMax;

        if ((horizontal != 0f || vertical != 0f) && !reallyDashing())
        {
            state = State.Moving;
        }

        if (isUp)
        {
            playAnimation("up");
        }
        else if (isDown)
        {
            playAnimation("down");
        }
        else if (isLeft)
        {
            playAnimation("left");
        }
        else if (isRight)
        {
            playAnimation("right");
        }
        else if (isTopLeft)
        {
            playAnimation("upleft");
        }
        else if (isTopRight)
        {
            playAnimation("upright");
        }
    }

    bool reallyDashing()
    {
        return dashState == DashState.Dashing || dashState == DashState.Minimizing ||
            dashState == DashState.Maximizing;
    }
}
