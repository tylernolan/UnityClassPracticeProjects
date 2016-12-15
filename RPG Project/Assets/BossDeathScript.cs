using UnityEngine;
using System.Collections;

public class BossDeathScript : MonoBehaviour {
	public GameObject bossDeathParticles;
	public GameObject bossDeathLight;
	private GameObject lightInstance;
	private bool isDead = false;
	public float maxLightRange = 50.0f;

	public void BossDeath() {
		Instantiate (bossDeathParticles, this.transform.position, Quaternion.identity);
		lightInstance = (GameObject)Instantiate (bossDeathLight, this.transform.position, Quaternion.identity);
		isDead = true;
		Camera.main.GetComponent<netLoop>().bossDead = true;
		Camera.main.GetComponent<BossCameraScript> ().enabled = false;
		MonoBehaviour follow = Camera.main.gameObject.GetComponent ("SmoothFollow") as MonoBehaviour;
		follow.enabled = true;
		var dance = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animation> ().GetClip("dance");
		GameObject.FindGameObjectWithTag ("Player").GetComponent<ClickToMove> ().idle = dance;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<ClickToMove> ().run = dance;

	}
	void Update(){
		if (isDead && lightInstance.GetComponent<Light>().range < maxLightRange) 
			lightInstance.GetComponent<Light> ().range += .5f;
	}
}
