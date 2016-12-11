using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour {
	public int damage = 10;
	public float durationUntilDestroy = 5.0f;
	public GameObject spellHit;
	private float startTime;
	void Start() {
		startTime = Time.time;
	}

	void Update() {
		if (Time.time - startTime >= durationUntilDestroy)
			DestroySpell ();
	}

	void DestroySpell() {
		Instantiate (spellHit, transform.position, transform.rotation);
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<mob> ().getHit (damage);
		}
		if (other.gameObject.tag != "Player")
			DestroySpell ();
	}
}
