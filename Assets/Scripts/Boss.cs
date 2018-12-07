using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	[SerializeField] private Transform A, B, destino;
	private bool facingRight;
	public Transform player;

	[SerializeField] private Animator animator;
	private float velocidade = 0;

	private int numberAttacks = 0;

	private bool seePlayer;

	void Start () {
		destino.position = B.position;
		transform.position = A.position;	
	}
	
	void Update () {
		if(Vector2.Distance(player.transform.position, transform.position) < 5){
			seePlayer = true;
		}

		transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

		if(transform.position == destino.position)
		{
			if(destino.position == A.position)
			{
				Flip();
				destino.position = B.position;
			}else if(destino.position == B.position)
			{
				Flip();
				destino.position = A.position;
			}
		}

		if(velocidade > 0.1){
			animator.SetBool("Walk", true);
		} else {
			animator.SetBool("Walk", false);
		}

		if (Vector2.Distance(player.transform.position, transform.position) <= 2 && seePlayer == true)
		{
			this.velocidade = 0f;
			if((player.transform.position.x > transform.position.x) && (facingRight == true)) Flip();

			if ((player.transform.position.x < transform.position.x)  && (facingRight == false))
				Flip();
			animator.SetBool("Attack", true);
		
		} else if((Vector2.Distance(player.transform.position, transform.position) > 3.5 && numberAttacks < 5) && seePlayer == true){
			this.velocidade = 4f;
			if ((destino.position == A.position) && (facingRight == false)) Flip();
			else if ((destino.position == B.position) && (facingRight == true)) Flip();
			animator.SetBool("Attack", false);
		}
	}

	void Flip(){
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
		facingRight = !facingRight;
	}
}

