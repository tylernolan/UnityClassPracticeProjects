using UnityEngine;
using System.Collections;

public class ShotgunScript : MonoBehaviour {

	public GameObject shot;
	public float fireRate;
	private float nextFire = 0.0f;
	public float spread = 10f;

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			Vector3 left = transform.position - new Vector3 (spread, 0, 0);
			Vector3 center = transform.position;
			Vector3 right = transform.position + new Vector3 (spread, 0, 0);
			nextFire = Time.time + fireRate;
			Instantiate (shot, left, transform.rotation);
			Instantiate (shot, center, transform.rotation);
			Instantiate (shot, right, transform.rotation);
			GetComponent<AudioSource> ().Play ();
		}

	}
}
