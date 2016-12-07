using UnityEngine;
using System.Collections;

public class FirewallScript : MonoBehaviour {
	public int damage = 10;
	public float damageInterval = 2.0f;
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<mob> ().TakeDamageOverTime (damage, damageInterval);
			other.GetComponent<mob> ().SlowDown (true, 0.25f);
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<mob> ().SlowDown (false, 0.25f); //factor isnt important here
			other.GetComponent<mob>().ResetTimer();
		}
	}
}
