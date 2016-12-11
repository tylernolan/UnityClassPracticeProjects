using UnityEngine;
using System.Collections;

public class EnemySpellScript : MonoBehaviour {
	public GameObject hitParticles;
	public int damage = 25;
	public float timeToDestroy = 10;
	private float timer = 0.0f;

	void Update() {
		timer += Time.deltaTime;
		if (timer >= timeToDestroy) {
			DestroySpell ();
		}
	}

	void DestroySpell() {
		Instantiate(hitParticles,transform.position,transform.rotation);
		Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.GetComponent<Fighter>().Get_Hit(damage);
		}
		if (other.gameObject.tag != "Enemy") {
			DestroySpell ();
		}
	}
}
