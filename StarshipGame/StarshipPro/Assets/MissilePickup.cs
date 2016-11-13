using UnityEngine;
using System.Collections;

public class MissilePickup : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			Done_GameController.missileCount = 3;
			Destroy (gameObject);
		}
	}
}
