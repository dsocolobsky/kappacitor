using UnityEngine;
using System.Collections;

public class SlowExplosion : MonoBehaviour
{

    Player player;
    bool touchingPlayer = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name.StartsWith("player") && !touchingPlayer)
        {
            touchingPlayer = true;
            player = col.gameObject.GetComponent<Player>();
        }
    }

    public void Damage()
    {
        if (touchingPlayer)
        {
            player.Slow(5.0f);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
