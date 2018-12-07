using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private Vida scriptVida;
	[SerializeField] private float jumpForce;
	private float moveInput = 0f;
	private Rigidbody2D rb2d;
	[SerializeField] private bool isGrounded;
	[SerializeField] public Transform groundCheck;
	public float checkRadious;
	public LayerMask whatIsGround;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .03f;
	private Vector3 m_Velocity = Vector3.zero;
	private float runSpeed = 5f;
	[SerializeField] private Animator animator;
	[SerializeField] private bool crouch;
	[SerializeField] private GameObject attack;
	[SerializeField] private GameObject attack2;
	private bool facingRight;
	private int i = 0;
	public bool FacingRight
	{
		get { return facingRight; }
	}
	private int x = 0;
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();	
	}
	
	void FixedUpdate(){

		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatIsGround);
		if(crouch == false && animator.GetBool("isAttacking") == false && animator.GetBool("isAttacking2") == false && scriptVida.vivo == true){
			moveInput = Input.GetAxisRaw("Horizontal") * runSpeed;
		} else{
			moveInput = 0f;
		}
		animator.SetFloat("Speed", Mathf.Abs(moveInput));

		Vector3 targetVelocity = new Vector2(moveInput, rb2d.velocity.y);
		rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		if(facingRight == true && moveInput > 0){
			Flip();
		} else if (facingRight == false && moveInput < 0){
			Flip();
		}
	}

	void Update () {
		if(isGrounded == true){
			animator.SetBool("isJumping", false);
		}else if (isGrounded == false && scriptVida.vivo == true){
			animator.SetBool("isJumping", true);
		}
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true && scriptVida.vivo == true){
			rb2d.AddForce(new Vector2(0f, jumpForce));
		}

		if (Input.GetKeyDown(KeyCode.DownArrow)){
			crouch = true;
			animator.SetBool("isCrouching", true);
		}else if (Input.GetKeyUp(KeyCode.DownArrow)){
			crouch = false;
			animator.SetBool("isCrouching", false);
		}
		if (Input.GetKeyDown(KeyCode.X)){
			animator.SetBool("isAttacking", true);
		}else if (!Input.GetKeyDown(KeyCode.X)){
			animator.SetBool("isAttacking", false);
		}
		if (Input.GetKeyDown(KeyCode.C)){
			animator.SetBool("isAttacking2", true);
		}else if (!Input.GetKeyDown(KeyCode.C)){
			animator.SetBool("isAttacking2", false);
		}
		if (scriptVida.vivo == false && x == 0){
			animator.SetTrigger("isDead");
			x++;
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
	public void onColliderAttack()
	{
		attack.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void offColliderAttack()
	{
		attack.GetComponent<BoxCollider2D>().enabled = false;
	}

	public void onColliderAttack2()
	{
		attack2.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void offColliderAttack2()
	{
		attack2.GetComponent<BoxCollider2D>().enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("enemy_attack"))
		{
			scriptVida.alterarVida(5);
		}
		if (other.gameObject.CompareTag("enemy_attack_skeleton"))
		{
			scriptVida.alterarVida(10);
		}
		if (other.gameObject.CompareTag("enemy_attack_hellhound"))
		{
			scriptVida.alterarVida(8);
		}
		if (other.gameObject.CompareTag("life"))
		{
			scriptVida.alterarVida(-100);
		}
		if (other.gameObject.CompareTag("queda"))
		{
			scriptVida.alterarVida(100);
			this.GetComponent<CapsuleCollider2D>().enabled = false;
			this.GetComponent<SpriteRenderer>().color = new Color (1, 0, 0, .5f);
			if (i == 0){
				rb2d.AddForce(new Vector2(0f, 1900f));
				i++;
			}
		}
	}
}
