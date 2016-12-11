using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {
	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<mob> ().SlowDown (true, 0.75f);
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<mob> ().SlowDown (false, 0.75f); //factor isnt important here
			other.GetComponent<mob>().ResetTimer();
		}
	}
}
