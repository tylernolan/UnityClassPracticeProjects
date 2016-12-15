using UnityEngine;
using System.Collections;

public class BossTriggerScript : MonoBehaviour {
	private MonoBehaviour cameraFollow;
	private netLoop netcode;

	void Start() {
		netcode = Camera.main.gameObject.GetComponent<netLoop> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			netcode.bossEnabled = true;
			cameraFollow = Camera.main.gameObject.GetComponent ("SmoothFollow") as MonoBehaviour;
			cameraFollow.enabled = false;
			Camera.main.gameObject.GetComponent<BossCameraScript> ().enabled = true;
			Destroy (gameObject);
		}
	}
}
