using UnityEngine;
using System.Collections;

public class ChangeLedAnimation : ChangeAnimation
{

    Led.State state = Led.State.MOVING;

    // Use this for initialization
    void Start()
    {
        prefix = "led_";
        previousAnimation = "down";
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change(Led.State state, float horizontal, float vertical)
    {
        this.state = state;

        if (vertical == 0 && horizontal == 0)
        {
            animator.Play(previousAnimation, 0, 0);
        }

        if (vertical == -1)
        {
            if (horizontal == -1)
            {
                play("left");
            }
            else if (horizontal == 1)
            {
                play("right");
            }
            else {
                play("down");
            }
        }
        else if (vertical == 1)
        {
            if (horizontal == -1)
            {
                play("left");
            }
            else if (horizontal == 1)
            {
                play("right");
            }
            else {
                play("up");
            }
        }
        else
        {
            if (horizontal == -1)
            {
                play("left");
            }
            else if (horizontal == 1)
            {
                play("right");
            }
        }
    }

    protected new void play(string anim)
    {
        if (state == Led.State.MOVING)
            animator.Play("led_" + anim);
        else if (state == Led.State.ATTACKING)
            animator.Play("led_attacking");

        previousAnimation = anim;
    }
}