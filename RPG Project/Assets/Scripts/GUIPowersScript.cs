using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIPowersScript : MonoBehaviour {
	public Texture2D[] images;
	private float backgroundHeight = 50;
	private float imageSize = 40;
	private float backgroundWidth;
	public float yPadding = 6.0f;
	public float xPadding=2.0f;
	private Rect canvasDimensions;
	public Texture2D backgroundImage;
	public Texture2D powerRechargeProgressImage;
	private Fighter player;
	private List<bool> activeList = new List<bool>();
	private SepcialAttack[] specialAttacks;
	// Use this for initialization
	void Start () {
		backgroundWidth = images.Length * (imageSize * xPadding) + xPadding;
		canvasDimensions = new Rect (Screen.width-backgroundWidth, Screen.height - backgroundHeight, backgroundWidth, backgroundHeight);
		xPadding = imageSize/2;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Fighter>();
		specialAttacks = player.GetComponentsInParent<SepcialAttack> ();
		for (int i = 0; i < images.Length; i++) {
			activeList.Add (false);
		}
	}

	/*
	 * The next two methods will need to be altered for each new power we add to the game. Unfortunately I was a lazy piece of shit and didn't feel like doing it any other way.
	 */
	public void setPowerImage(string imageToSet, Texture2D newImage) {
		switch (imageToSet) {
		case "Fire":
			images [0] = newImage;
			activeList [0] = !activeList [0];
			break;
		case "Expl":
			images [1] = newImage;
			activeList [1] = !activeList [1];
			break;
		case "Water":
			images [2] = newImage;
			activeList [2] = !activeList [2];
			break;
		case "Health":
			images [3] = newImage;
			activeList [3] = !activeList [3];
			break;
		case "Wind":
			images [4] = newImage;
			activeList [4] = !activeList [4];
			break;
		}
	}

	public Texture2D getPowerImage(string imageName) {
		switch (imageName) {
		case "Fire":
			return images [0];
		case "Expl":
			return images [1];
		case "Water":
			return images [2];
		case "Health":
			return images [3];
		case "Wind":
			return images [4];
		}
		return null;
	}

	void OnGUI() {
		DrawFrame ();
		DrawBar ();
	}

	void DrawFrame()
	{
		
		GUI.DrawTexture (canvasDimensions, backgroundImage);
	}

	void DrawBar()
	{
		int num = 0;
		for (int i = images.Length-1; i >= 0; i--) {
			num++;
			float xPos = Screen.width-(((backgroundWidth / images.Length)*num) - xPadding);
			GUI.DrawTexture (new Rect (xPos, Screen.height - (backgroundHeight)+yPadding, imageSize, imageSize), images [i]);
			if (specialAttacks [i].inAction) {
				SepcialAttack attack = specialAttacks [i];
				float elapsedTime = Time.time - attack.activatedTime;
				float percentage = (attack.waittime - elapsedTime) / attack.waittime;
				GUI.DrawTexture (new Rect (xPos, Screen.height - (backgroundHeight/2)-(imageSize/8), imageSize * percentage, imageSize/4), powerRechargeProgressImage);
			}
		}
		/*num = 0;
		for (int i = specialAttacks.Length-1; i >= 0; i--) {
			if (specialAttacks [i].inAction) {
				SepcialAttack attack = specialAttacks [i];
				num++;
				float xPos = Screen.width - (((backgroundWidth / images.Length) * num) - xPadding);
				float elapsedTime = Time.time - attack.activatedTime;
				float percentage = (attack.waittime - elapsedTime) / attack.waittime;
				GUI.DrawTexture (new Rect (xPos, Screen.height - (backgroundHeight/2)-(imageSize/8), imageSize * percentage, imageSize/4), powerRechargeProgressImage);
			}
		}*/
	}
		
}
