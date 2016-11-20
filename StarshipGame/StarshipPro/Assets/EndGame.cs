using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	private float time = 0;
	private bool enableGUI = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 6) {
			enableGUI = true;
			if (Input.anyKey) {
				Application.Quit ();
			}
		}
	}

	void OnGUI() {
		if(enableGUI)
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2, 200, 100), "End Game");
	}
}
