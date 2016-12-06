using UnityEngine;
using System.Collections;

public class KillAllEnemies : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Collider[] collisions = Physics.OverlapSphere (transform.position, 10);
		for (int i = 0; i < collisions.Length; i++) {
			Collider other = collisions [i];
			if (other.gameObject.tag == "Enemy") {
				mob enemy = other.gameObject.GetComponent<mob> ();
				enemy.getHit (enemy.health);
			}
		}
	}
}
