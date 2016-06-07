using UnityEngine;

// Este script cambia las animaciones de los personajes
// segun la direccion en la que apuntan
// Se basa en la premisa de que cada personaje tiene 6
// direcciones (up, down, downleft, downright, upleft, upright)
public class ChangeAnimation : MonoBehaviour
{
    // Prefix para el nombre de los sprites
    // "capacitor_X , player_X, etc.
    public string prefix;

    protected Animator animator;

    // Cual fue la ultima animacion que estabamos usando?
    // Esto se utiliza para las animaciones de idle
    protected string previousAnimation;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        // Comenzar con una animacion en idle
        previousAnimation = prefix + "idle";
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Este metodo es llamado cada vez que cambiamos de direccion
    // Se le pasa la direccion en X e Y, y en base a eso se
    // determina que animacion debemos utilizar.
    public void Change(float horizontal, float vertical)
    {
        if (vertical == 0 && horizontal == 0)
        {
            animator.Play(previousAnimation, 0, 0);
        }

        if (vertical == -1)
        {
            if (horizontal == -1)
            {
                play("downleft");
            }
            else if (horizontal == 1)
            {
                play("downright");
            }
            else {
                play("down");
            }
        }
        else if (vertical == 1)
        {
            if (horizontal == -1)
            {
                play("upleft");
            }
            else if (horizontal == 1)
            {
                play("upright");
            }
            else {
                play("up");
            }
        }
        else
        {
            if (horizontal == -1)
            {
                play("upleft");
            }
            else if (horizontal == 1)
            {
                play("upright");
            }
        }
    }

    protected void play(string anim)
    {
        animator.Play(prefix + anim);
        previousAnimation = prefix + anim;
    }
}
