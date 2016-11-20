using UnityEngine;
using System.Collections;

public class BurstGun : MonoBehaviour {
	public GameObject shot;
	public float fireRate;
	public int burstCount = 2;
	private float nextFire = 0.0f;
	private int fireCount = 0;
	private bool keepFiring = false;
	public float burstRate;
	private float burstRateCount;

	// Update is called once per frame
	void Update () {
		if ((Input.GetButton ("Fire1") && Time.time > nextFire && fireCount == 0) || (keepFiring && Time.time > burstRateCount)) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, transform.position, transform.rotation);
			GetComponent<AudioSource> ().Play ();
			fireCount++;
			burstRateCount = Time.time + burstRate;
			if (fireCount >= burstCount) {
				keepFiring = false;
				fireCount = 0;
			}
			else
				keepFiring = true;
		}

	}
}
