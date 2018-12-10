using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
    public AudioClip soundPotion;
    // Use this for initialization
    // void Start () {

    // }

    // // Update is called once per frame
    // void Update () {

    // }

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
            AudioSource.PlayClipAtPoint(soundPotion, transform.position);
			Destroy(this.gameObject);
		}	
	}
}
