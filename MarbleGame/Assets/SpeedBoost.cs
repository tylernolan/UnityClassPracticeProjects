using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour {
	private MarbleControl mc;
	private Rigidbody mrb;
	private bool active = false;
	private Vector3 veloc;
	private float duration = 0.0f;
	// Use this for initialization
	void Start () {
		mc = GameObject.Find ("Marble").GetComponent<MarbleControl> ();
		mrb = GameObject.Find ("Marble").GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			duration += Time.deltaTime;
			mrb.velocity = veloc;
			if (duration >= 1.0f) {
				active = false;
			}
		}
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			duration = 0.0f;
			veloc = new Vector3 (mrb.velocity.x * 2, mrb.velocity.y * 2, mrb.velocity.z * 2);
			active = true;
		}
	}
}
