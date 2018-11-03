using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHoundController : MonoBehaviour {

	[SerializeField]
	private Transform A, B, destino;

	[SerializeField]
	private float velocidade;

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

		if(velocidade > 0.1f){
			animator.SetFloat("Speed", velocidade);
		}
	}

	void Flip(){
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
