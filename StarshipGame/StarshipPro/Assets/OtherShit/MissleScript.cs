using UnityEngine;
using System.Collections;

public class MissleScript : MonoBehaviour {
	public GameObject explosionEffect;
	public GameObject enemyExplosion;
	public AudioSource soundEffectPlayer;
	private Done_GameController gc;
	// Use this for initialization
	//poop
	void Start () {
		soundEffectPlayer = GameObject.Find ("SoundEffects").GetComponent<AudioSource>();
		gc = GameObject.FindWithTag ("GameController").GetComponent<Done_GameController> ();
	}
	public void Explode() {
		soundEffectPlayer.Play ();
		Instantiate (explosionEffect, this.gameObject.transform.position, Quaternion.identity);
		Collider[] collisions = Physics.OverlapSphere (gameObject.transform.position, 15f);
		foreach (Collider current in collisions) {
			if (current.gameObject.tag == "Enemy") {
				Instantiate (enemyExplosion, current.gameObject.transform.position, Quaternion.identity);
				gc.AddScore (25);
				Destroy (current.gameObject);
			}
		}
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Explode ();
		} 
	}
}
