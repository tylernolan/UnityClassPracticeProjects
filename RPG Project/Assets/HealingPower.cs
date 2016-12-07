using UnityEngine;
using System.Collections;

public class HealingPower : MonoBehaviour {
	public int healAmount = 25;
	// Use this for initialization
	void Start () {
		Fighter player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Fighter> ();
		if (player.Health + healAmount > 100)
			player.Health = 100;
		else if (player.Health + healAmount < 100)
			player.Health += healAmount;
		else
			player.Mana += 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
