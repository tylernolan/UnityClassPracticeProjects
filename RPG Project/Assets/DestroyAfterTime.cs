using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
	public float time = 5;
	private float timer = 0.0f;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= time)
			Destroy (gameObject);
	}
}
