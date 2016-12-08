﻿using UnityEngine;
using System.Collections;

public class SepcialAttack : MonoBehaviour {

	public Fighter player;
	public KeyCode key;
	public int StunTime;
	public double damage_percentage;
	public bool inAction;
	public GameObject ParticlePrefab;
	private GameObject instantiated;
	private Vector3 lastPos;
	private bool usemove = true;
	public float waittime;
	public int manaConsumptionAmount = 25;
	private GUIPowersScript powerBar;
	public string powerImageName;
	public Texture2D activeImg;
	public Texture2D notActiveImg;

	// Use this for initialization
	void Start () {
		powerBar = GameObject.Find ("PowerBar").GetComponent<GUIPowersScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Vector3.Distance(lastPos, transform.position) > 0.01f) 
		{ 
			lastPos = transform.position; 

		}	

		if (Input.GetKeyDown (key) && usemove && (player.Mana >= manaConsumptionAmount)) 
		{
			powerBar.setPowerImage (powerImageName, activeImg);
			player.Use_Mana (manaConsumptionAmount);
			usemove = false;
			player.resetAttack ();
			player.Special_attack = true;
			inAction = true;
			lastPos = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);

			instantiated = (GameObject)Instantiate (ParticlePrefab, 
	        lastPos,  transform.rotation);

			StopCoroutine ("Destroy");    // Interrupt in case it's running
			StartCoroutine ("Destroy");
			player.Special_attack = false;

		}

		if (inAction) 
		{
			if(player.opponent!= null)
			{
			player.Attack (StunTime, damage_percentage, key);
			}
			if (GetComponent<Animation>()[player.attack.name].time > 0.9*GetComponent<Animation>()[player.attack.name].length)
			{
				inAction = false;
				player.Special_attack = false;
			}
		}
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(waittime);
		powerBar.setPowerImage (powerImageName, notActiveImg);
		if (instantiated != null)
		{
			Destroy(instantiated); 
			usemove = true;
		}
		player.Special_attack = false;
		inAction = false;
	}























}
