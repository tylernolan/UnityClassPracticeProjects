using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {
	public GameObject defaultGun;
	private GameObject newWeapon;
	private bool changeWeapon = false;
	private float duration = 0;
	private float maxDuration;
	public GameObject[] weapons;

	
	// Update is called once per frame
	void Update () {
		if(changeWeapon) {
			duration += Time.deltaTime;
			if (duration >= maxDuration) {
				changeWeapon = false;
				//if(newWeapon.tag != "Shield")
					defaultGun.SetActive (true);
				newWeapon.SetActive (false);
			}
		}
	}

	public void SwitchWeapon(string name, float time) {
		bool found = false;
		for (int i = 0; i < weapons.Length && !found; i++) {
			if (weapons [i].name.Equals(name)) {
				if(newWeapon != null)
					newWeapon.SetActive (false);
				newWeapon = weapons [i];
				found = true;
			}
		}
		duration = 0;
		maxDuration = time;
		newWeapon.SetActive (true);
		defaultGun.SetActive (false);
		changeWeapon = true;
	}
}
