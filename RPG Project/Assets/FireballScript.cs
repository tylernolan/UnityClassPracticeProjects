using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
	public int damage = 10;
	public float durationUntilDestroy = 5.0f;
	private float startTime;
	void Start() {
		startTime = Time.time;
	}

	void Update() {
		if (Time.time - startTime >= durationUntilDestroy)
			Destroy (gameObject);
	}
	
	// l;kgsidjlkgsdlkgj;dlskjg;lkdsl;kgjsd
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<mob> ().getHit (damage);
		}
		if(other.gameObject.tag != "Player")
			Destroy (gameObject);
	}
}
