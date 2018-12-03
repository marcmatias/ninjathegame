using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {


	[SerializeField]
	private int vida;
	[SerializeField]
	private Text textVida;
	
	void Start () {
		
	}
	
	
	void Update () {
		if(this.vida <= 0)
		{
			print("Morrer");
		}
	}

	public void diminuirVida(int vida)
	{
		this.vida -= vida;
		if (this.vida <= 0)
		{
			this.vida = 0;
		}
		textVida.text = "Vida: " + this.vida.ToString();
	}
}
