using UnityEngine;
using System.Collections;

public class HealingPower : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Fighter player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Fighter> ();
		if (player.Health < 100)
			player.Health += 25;
		else
			player.Mana += 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
