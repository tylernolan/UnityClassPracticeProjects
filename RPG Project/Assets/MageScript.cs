using UnityEngine;
using System.Collections;

public class MageScript : MonoBehaviour {
	public GameObject spellCast;
	public GameObject spawner;
	public float spellSpeed;
	public void CastSpell() {
		transform.LookAt (GameObject.FindGameObjectWithTag("Player").transform);
		GameObject spell = (GameObject)Instantiate (spellCast, spawner.transform.position, transform.rotation);
		spell.GetComponent<Rigidbody>().velocity = spellSpeed * (spell.transform.forward);
	}
}
