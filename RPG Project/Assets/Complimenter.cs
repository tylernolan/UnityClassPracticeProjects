using UnityEngine;
using System.Collections;

public class Complimenter : MonoBehaviour {
	static string[] compliments;
	public TextAsset text;
	// Use this for initialization

	void Start() {
		string strText = text.text;
		compliments = strText.Split ("\n".ToCharArray());
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.L)) {
			Camera.main.gameObject.GetComponent<netLoop> ().setCommandLog ("Player", " says: " + Complimenter.getRandomCompliment ());
		}
	}
	public static string getRandomCompliment(){
		return compliments [Random.Range (0, compliments.Length - 1)];
	}

}
