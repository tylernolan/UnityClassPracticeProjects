using UnityEngine;
using System.Collections;

public class GUIPowersScript : MonoBehaviour {
	public Texture2D[] images;
	private float backgroundHeight = 50;
	private float imageSize = 40;
	private float backgroundWidth;
	public float yPadding = 6.0f;
	public float xPadding=2.0f;
	private Rect canvasDimensions;
	public Texture2D backgroundImage;
	// Use this for initialization
	void Start () {
		backgroundWidth = images.Length * (imageSize * xPadding) + xPadding;
		canvasDimensions = new Rect (Screen.width-backgroundWidth, Screen.height - backgroundHeight, backgroundWidth, backgroundHeight);
		xPadding = imageSize/2;
	}
	
	public void setPowerImage(string imageToSet, Texture2D newImage) {
		switch (imageToSet) {
		case "Fire":
			images [0] = newImage;
			break;
		case "Expl":
			images [1] = newImage;
			break;
		case "Water":
			images [2] = newImage;
			break;
		case "Health":
			images [3] = newImage;
			break;
		case "Wind":
			images [4] = newImage;
			break;
		}
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
			float xPos = Screen.width-(((backgroundWidth / images.Length)*num) + xPadding);
			GUI.DrawTexture (new Rect (xPos, Screen.height - (backgroundHeight)+yPadding, imageSize, imageSize), images [i]);
		}
	}
}
