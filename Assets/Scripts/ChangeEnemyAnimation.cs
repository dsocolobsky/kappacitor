// Este script cambia las animaciones del capacitor,
// dependiendo de si se esta moviendo, atacando o muriendo

using UnityEngine;

public class ChangeEnemyAnimation : ChangeAnimation
{

    public Enemy.State state = Enemy.State.MOVING;

    // Use this for initialization
    void Start()
    {
        prefix = "capacitor_";
        previousAnimation = "down";
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    new public void Change(float horizontal, float vertical)
    {
        play(ReturnDirection(horizontal, vertical));
    }

    public string ReturnDirection(float horizontal, float vertical)
    {
        if (vertical == -1)
        {
            if (horizontal == -1)
            {
                return "downleft";
            }
            else if (horizontal == 1)
            {
                return "downright";
            }
            else {
                return "down";
            }
        }
        else if (vertical == 1)
        {
            if (horizontal == -1)
            {
                return "upleft";
            }
            else if (horizontal == 1)
            {
                return "upright";
            }
            else {
                return "up";
            }
        }
        else
        {
            if (horizontal == -1)
            {
                return "upleft";
            }
            else if (horizontal == 1)
            {
                return "upright";
            }
        }

        return "";
    }

    // Seleccionar la animacion dependiendo del estado
    protected new void play(string anim)
    {
        if (state == Enemy.State.MOVING)
            animator.Play(prefix + anim);
        else if (state == Enemy.State.ATTACKING)
            animator.Play(prefix + "attack_" + anim);
        else if (state == Enemy.State.DYING)
            animator.Play(prefix + "death_" + anim);

        previousAnimation = anim;
    }

    public void changeState(Enemy.State state)
    {
        this.state = state;
    }


}
