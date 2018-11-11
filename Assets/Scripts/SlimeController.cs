using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

	[SerializeField]
	private Transform A, B, destino;

	private float velocidade = 2f;

	public Transform player;

	[SerializeField]
	private Animator animator;	
	private int numberAttacks = 0;
	[SerializeField]
	private SpriteRenderer enemySr;
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

		if (Vector2.Distance(player.transform.position, transform.position) <= 1.3f)
		{
			this.velocidade = 0f;
			animator.SetBool("Attack", true);
		} else if(Vector2.Distance(player.transform.position, transform.position) > 1.3f){
			this.velocidade = 2f;
			animator.SetBool("Attack", false);
		}
	}

	void Flip(){
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Attack"))
		{
			numberAttacks += 1;
			
			if(numberAttacks <= 2){
				animator.SetBool("Hurt", true);
			} else if(numberAttacks >= 3){
				animator.SetTrigger("Die");
				StartCoroutine(WaitAndAnimate(0.4f, other));
			}
		}

		else if (other.CompareTag("Attack2"))
		{
			numberAttacks += 2;
			if(numberAttacks <= 2){
				animator.SetBool("Hurt", true);
			} else if(numberAttacks >= 3){
				StartCoroutine(WaitAndAnimate(0.4f, other));
				animator.SetTrigger("Die");
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Attack") || other.CompareTag("Attack2"))
		{
			animator.SetBool("Hurt", false);
		}
	}

	public IEnumerator WaitAndAnimate(float waitTime, Collider2D other) {
		yield return new WaitForSeconds(waitTime);
		Destroy(this.gameObject);
		}
}

