using UnityEngine;
using System.Collections;

public class StunTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 size = GetComponent<BoxCollider> ().size;
		Vector3 areaEffected = new Vector3 (size.x / 2, size.y / 2, size.z / 2);
		Collider[] collisions = Physics.OverlapBox (transform.position,size);
		for (int i = 0; i < collisions.Length; i++) {
			Collider other = collisions [i];
			if (other.gameObject.tag == "Enemy") {
				mob enemy = other.gameObject.GetComponent<mob> ();
				enemy.GetStun (15);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			mob enemy = other.GetComponent<mob> ();
			enemy.GetStun (15);
		}
	}
}
