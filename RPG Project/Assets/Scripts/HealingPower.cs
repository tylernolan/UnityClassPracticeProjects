using UnityEngine;
using System.Collections;

public class HealingPower : MonoBehaviour {
	public int healAmount = 25;
	private bool heal = true;
	// Use this for initialization
	//
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (heal) {
			Fighter player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Fighter> ();
			if (player.Health == player.maxHealth)
				player.Mana += 50;
			else if (player.Health + healAmount > player.maxHealth)
				player.Health = 100;
			else if (player.Health + healAmount < player.maxHealth)
				player.Health += healAmount;
			heal = false;
		}
	}
}
