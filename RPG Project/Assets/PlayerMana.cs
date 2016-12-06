using UnityEngine;
using System.Collections;

public class PlayerMana : MonoBehaviour {

	public Texture2D frame;
	public Rect framePosition;
	public Fighter Player;
	public float horizontalDistance;
	public float verticalDistance;
	public float width;
	public float height;
	public float manaPercent;
	public Texture2D manaBar;
	public Rect manaBarPosition;

	// Use this for initialization
	void Start () 
	{
		framePosition.y = Screen.height * 0.9f;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Player != null) 
		{
			manaPercent = (float)Player.Mana / (float)Player.maxMana;
		} 
		else 
		{
			manaPercent =  0;
		}
	}

	void OnGUI()
	{
		if (Player != null) 
		{
			DrawFrame ();
			DrawBar ();
		}
	}


	void DrawFrame()
	{
		framePosition.x = (Screen.width - framePosition.width) /2 - (framePosition.width*2);
		//float width = 200 / 0.39f;
		//for added compretion 
		//framePosition.width = Screen.width* width;
		//framePosition.height = Screen.height / 0.0625f;
		GUI.DrawTexture (framePosition,frame);
	}

	void DrawBar()
	{
		manaBarPosition.x = framePosition.x + (framePosition.width * horizontalDistance);
		manaBarPosition.y = framePosition.y + (framePosition.height * verticalDistance);
		manaBarPosition.width = framePosition.width * width* manaPercent;
		manaBarPosition.height = framePosition.height * height;
		GUI.DrawTexture (manaBarPosition,manaBar);
	}
}
