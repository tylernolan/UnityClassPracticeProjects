using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Done_GameController.maxNumberHitsBeforeDeath++;
			Destroy (this.gameObject);
		}
	}
		
}
