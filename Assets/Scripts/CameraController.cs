using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField]
	private Transform esq, dir;
	private PlayerController player;
	
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	
	void Update () {
		if(player.transform.position.x > esq.position.x && player.transform.position.x < dir.position.x) { 
			transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		}
	}
}
