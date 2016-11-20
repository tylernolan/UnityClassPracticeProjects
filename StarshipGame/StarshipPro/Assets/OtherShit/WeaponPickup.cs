using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour {
	public GameObject pickupType;
	public float pickupDuration;
	public GunManager manager;

	void Start() {
		manager = GameObject.Find ("GunManager").GetComponent<GunManager>();
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			manager.SwitchWeapon (pickupType.name, pickupDuration);
			Destroy (this.gameObject);
		}
	}
}
