using UnityEngine;
using System.Collections;

public class MissleScript : MonoBehaviour {
	public GameObject explosionEffect;
	public GameObject enemyExplosion;
	public AudioSource soundEffectPlayer;
	// Use this for initialization
	void Start () {
		soundEffectPlayer = GameObject.Find ("SoundEffects").GetComponent<AudioSource>();
	}
	public void Explode() {
		soundEffectPlayer.Play ();
		Instantiate (explosionEffect, this.gameObject.transform.position, Quaternion.identity);
		Collider[] collisions = Physics.OverlapSphere (gameObject.transform.position, 15f);
		foreach (Collider current in collisions) {
			if (current.gameObject.tag == "Enemy") {
				Instantiate (enemyExplosion, current.gameObject.transform.position, Quaternion.identity);
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
