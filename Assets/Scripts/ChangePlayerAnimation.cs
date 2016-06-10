using UnityEngine;

// Este script cambia la animacion del personaje principal
// Difiere del resto ya que el player cambia de animacion
// segun donde apunte el mouse
public class ChangePlayerAnimation : ChangeAnimation
{
	Vector3 mousePos;
    
	// Estos son los angulos utilizados para determinar en que
	// momento se debe cambiar de animacion, dependiendo de la
	// posicion del mouse
	//float topMin = 45f;
	//float topMax = 135f;

	//float botMin = -45f;
	//float botMax = -135f;

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

	bool moving = false;

	// Use this for initialization
	void Start ()
	{
		prefix = "player_";
		animator = GetComponent<Animator> ();
		previousAnimation = "down";

		mousePos = new Vector3 ();
	}

	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		float angle = getAngle ();

		bool isUp = angle > topMin && angle < topMax;
		bool isDown = angle < botMin && angle > botMax;
		bool isLeft = angle > 157 || angle < -112f;
		bool isRight = angle > rightMin && angle < rightMax;
		bool isTopLeft = angle > topLeftMin && angle < topLeftMax;
		bool isTopRight = angle > topRightMin && angle < topRightMax;

		moving = (horizontal != 0f || vertical != 0f);

		if (isUp) {
			play ("up");
		} else if (isDown) {
			play ("down");
		} else if (isLeft) {
			play ("left");
		} else if (isRight) {
			play ("right");
		} else if (isTopLeft) {
			play ("upleft");
		} else if (isTopRight) {
			play ("upright");
		}
	}

	protected new void play (string anim)
	{
		if (moving)
			animator.Play (prefix + anim);
		else
			animator.Play (prefix + "idle_" + anim);

		previousAnimation = anim;
	}

	// Devuelve el angulo que hay desde el jugador hasta la posicion del mouse
	float getAngle ()
	{
		mousePos = Input.mousePosition;
		Vector2 distance = mousePos - Camera.main.WorldToScreenPoint (transform.position);
		return Mathf.Atan2 (distance.y, distance.x) * Mathf.Rad2Deg;
	}
}
