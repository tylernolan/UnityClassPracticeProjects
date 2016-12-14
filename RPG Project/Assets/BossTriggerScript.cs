using UnityEngine;
using System.Collections;

public class BossTriggerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
			Camera.main.gameObject.GetComponent<netLoop> ().bossEnabled = true;
	}
}
