using UnityEngine;
using System.Collections;

public class DashAbility : MonoBehaviour
{
    public enum DashState
    {
        Ready,
        Minimizing,
        Dashing,
        Maximizing,
        Cooldown
    }

    public DashState dashState;

    public float maxDash = 3.0f;

    public float cooldown = 6.0f;
    float cooldownTimer = 0.0f;


    Player player;
    float savedVelocity;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                bool isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    savedVelocity = player.speed;
                    switchState(DashState.Minimizing);
                }
                break;
            case DashState.Cooldown:
                cooldownTimer += Time.deltaTime;
                if (cooldownTimer >= cooldown)
                {
                    switchState(DashState.Ready);
                }
                break;
        }
    }

    void switchState(DashState state)
    {
        switch (state)
        {
            case DashState.Ready:
                cooldownTimer = 0.0f;
                break;
            case DashState.Minimizing:
                player.speed = 0.0f;
                player.playSound(player.minimize);
                player.setDashing(true);
                break;
            case DashState.Dashing:
                player.speed = savedVelocity * 3f;
                break;
            case DashState.Maximizing:
                player.speed = 0.0f;
                player.playSound(player.maximize);
                break;
            case DashState.Cooldown:
                player.speed = savedVelocity;
                player.setDashing(false);
                break;
        }

        dashState = state;
    }

    public bool dashing()
    {
        return dashState == DashState.Dashing || dashState == DashState.Minimizing ||
            dashState == DashState.Maximizing;
    }
}
