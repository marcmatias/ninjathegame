using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHoundController : MonoBehaviour {

	[SerializeField]
	private Transform A, B, destino;
	private float velocidade = 2f;

	[SerializeField]
	private Animator animator;
	public Transform player;
	private bool facingRight = true;

	private int numberAttacks = 0;

	[SerializeField]
	private SpriteRenderer enemySr;

	[SerializeField]
	private BoxCollider2D enemyPc;

	private bool died;
	
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

		if(velocidade > 0.1f && died != true){
			animator.SetFloat("Speed", velocidade);
		}

		if ((Vector2.Distance(player.transform.position, transform.position) < 6 && Vector2.Distance(player.transform.position, transform.position) > 2) && died != true)
		{
			this.velocidade = 5f;
			// animator.SetBool("Attack", false);
			animator.SetBool("Run", true);
		}
		if (Vector2.Distance(player.transform.position, transform.position) <= 2 ){
			if((player.transform.position.x > transform.position.x) && (facingRight == true)) animator.SetTrigger("Attack");
			if((player.transform.position.x < transform.position.x) && (facingRight == false)) animator.SetTrigger("Attack");
		}
		if ((Vector2.Distance(player.transform.position, transform.position) > 6) && died != true) {
			this.velocidade = 2f;
			animator.SetBool("Run", false);
		}
	}

	void Flip(){
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
		facingRight = !facingRight;
	}

	public void AttackOn(){
		transform.position = new Vector3(transform.position.x, -1.99f, transform.position.z);
	}

	public void AttackOff(){
		transform.position = new Vector3(transform.position.x, -2.296204f, transform.position.z);
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
		if(numberAttacks < 3) enemySr.color = new Color (1, 1, 1, 1);
		else {
			Destroy(this.gameObject);
		}
	}

	public void Attacks(int numberAttacks){
		if(numberAttacks < 3){
			enemySr.color = new Color (1, 0, 0, .4f);
			StartCoroutine(WaitAndAnimate(0.2f, numberAttacks));
		} else if(numberAttacks > 2){
			died = true;
			enemySr.color = new Color (1, 0, 0, .3f);
			this.velocidade = 0.1f;
			StartCoroutine(WaitAndAnimate(0.5f, numberAttacks));
		}
	}
}
