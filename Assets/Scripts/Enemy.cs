using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	// private PlayerController player;
	// [SerializeField]
	// private float speed;
	// [SerializeField]
	// private bool facingRight;
	// private SlimeController slime;
	// SlimeController enemy;
	
	void Start () {
		// player = FindObjectOfType<PlayerController>();
	}
	
	void Update () {
	// 	if((player.transform.position.x > transform.position.x) && player.FacingRight)
	// 	{
	// 		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	// 	}

	// 	if ((player.transform.position.x < transform.position.x) && !player.FacingRight)
	// 	{
	// 		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	// 	}

		// if(player.transform.position.x > transform.position.x)
		// {
		// 	if (!facingRight)
		// 	{
		// 		Flip();
		// 	}
		// 	facingRight = true;
		// }

		// if (player.transform.position.x < transform.position.x)
		// {
		// 	if (facingRight)
		// 	{
		// 		Flip();
		// 	}
		// 	facingRight = false;
		// }
	 }

	// public void Flip()
	// {
	// 	float x = transform.localScale.x * -1;
	// 	transform.localScale = new Vector2(x, transform.localScale.y);
	// }

	
}
