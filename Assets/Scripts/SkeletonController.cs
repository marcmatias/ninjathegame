using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour {

	[SerializeField]
	private Transform A, B, destino;
	private float velocidade = 2f;

	public Transform player;

	[SerializeField]
	private Animator animator;
	
	void Start () {
		destino.position = B.position;
		transform.position = A.position;
	}
	
	
	void Update () {
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

		if (Vector2.Distance(player.transform.position, transform.position) <= 1)
		{
			this.velocidade = 0f;
			animator.SetBool("Attack", true);
		} else if(Vector2.Distance(player.transform.position, transform.position) > 3){
			this.velocidade = 2f;
			animator.SetBool("Attack", false);
		}
	}

	void Flip(){
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
