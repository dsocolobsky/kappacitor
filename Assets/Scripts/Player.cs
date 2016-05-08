using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Animator animator;
    string previousAnimation;

    public float speed;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        previousAnimation = "capacitor_idle";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0);
        transform.position += move * speed * Time.deltaTime;

        animator.speed = 1f;

        if (vertical == 0 && horizontal == 0)
        {
            animator.Play(previousAnimation, 0, 0);
        }

        if (vertical == -1)
        {
            if (horizontal == -1)
            {
                animator.Play("capacitor_downleft");
                previousAnimation = "capacitor_downleft";
            }
            else if (horizontal == 1)
            {
                animator.Play("capacitor_downright");
                previousAnimation = "capacitor_downright";
            }
            else {
                animator.Play("capacitor_down");
                previousAnimation = "capacitor_down";
            }
        }
        else if (vertical == 1)
        {
            if (horizontal == -1)
            {
                animator.Play("capacitor_upleft");
                previousAnimation = "capacitor_upleft";
            }
            else if (horizontal == 1)
            {
                animator.Play("capacitor_upright");
                previousAnimation = "capacitor_upright";
            }
            else {
                animator.Play("capacitor_up");
                previousAnimation = "capacitor_up";
            }
        }
        else
        {
            if (horizontal == -1)
            {
                animator.Play("capacitor_upleft");
                previousAnimation = "capacitor_upleft";
            }
            else if (horizontal == 1)
            {
                animator.Play("capacitor_upright");
                previousAnimation = "capacitor_upright";
            }
        }
    }
}
