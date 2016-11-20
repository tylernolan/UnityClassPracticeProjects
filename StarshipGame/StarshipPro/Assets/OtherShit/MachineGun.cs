using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour {

	public GameObject shot;
	public float fireRate;
	private float nextFire = 0.0f;

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, transform.position, transform.rotation);
			GetComponent<AudioSource> ().Play ();
		}

	}
}
