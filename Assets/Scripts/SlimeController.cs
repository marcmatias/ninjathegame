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
	[SerializeField]
	private bool facingRight;
	[SerializeField]
	private PolygonCollider2D enemyPc;
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

		if (Vector2.Distance(player.transform.position, transform.position) <= 1.5f)
		{
			this.velocidade = 0f;
			if((player.transform.position.x > transform.position.x) && (facingRight == true)) Flip();

			if ((player.transform.position.x < transform.position.x)  && (facingRight == false)) Flip();
			animator.SetBool("Attack", true);
		} else if(Vector2.Distance(player.transform.position, transform.position) > 1.5f){
			this.velocidade = 2f;
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
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Attack"))
		{
			numberAttacks += 1;
			Attacks(numberAttacks);
		}

		else if (other.CompareTag("Attack2"))
		{
			numberAttacks += 2;
			Attacks(numberAttacks);
		}
	}
	public IEnumerator WaitAndAnimate(float waitTime, int numberAttacks) {
		yield return new WaitForSeconds(waitTime);
		if(numberAttacks < 3)enemySr.color = new Color (1, 1, 1, 1);
		else Destroy(this.gameObject);
	}

	public void Attacks(int numberAttacks){
		if(numberAttacks < 3){
			enemySr.color = new Color (1, 0, 0, .5f);
			StartCoroutine(WaitAndAnimate(0.2f, numberAttacks));
		} else if(numberAttacks > 2){
			enemyPc.enabled = false;
			animator.SetTrigger("Die");
			StartCoroutine(WaitAndAnimate(0.4f, numberAttacks));
		}
	}

}

