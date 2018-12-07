using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {


	[SerializeField]
	private int vida;
	[SerializeField]
	private Text textVida;

	public bool vivo = true;
	
	void Start () {
		
	}
	
	
	void Update () {
		if(this.vida == 0)
		{
			vivo = false;
		}
	}

	public void alterarVida(int vida)
	{
		this.vida -= vida;
		if (this.vida <= 0)
		{
			this.vida = 0;
		} else if (this.vida > 100)
		{
			this.vida = 100;
		}
		textVida.text = "Vida: " + this.vida.ToString();
	}
}
