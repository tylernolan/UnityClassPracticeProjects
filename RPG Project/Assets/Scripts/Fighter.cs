using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	public GameObject opponent;
	public AnimationClip attack;
	public AnimationClip dies;
	public int damage;
	public double impactTime;
	public bool hit = false;
	public double range;
	public int maxHealth;
	public int Health;
	public int maxMana;
	public int Mana;
	public bool Special_attack;
	//controls animations on death 
	public bool started;
	public bool ended;
	public float escapeTime = 10;
	public float countDown;
	public float manaRechargeTime = 0.5f;
	private float manaCountdown = 0.0f;
	private float spellCooldown = 2.0f;
	private float lastSpellTime = 0.0f;
	public int spellCost = 10;
	public KeyCode spellKey = KeyCode.LeftShift;
	public GameObject fireBall;
	public GameObject magicEmitter;


	// Use this for initialization
	void Start () 
	{
		Health = maxHealth;
		Mana = maxMana;
	}
	
	// Update is called once per frame
	void Update () 
	{
		manaCountdown += Time.deltaTime;
		if (Mana < maxMana && manaCountdown >= manaRechargeTime) {
			Mana++;
			manaCountdown = 0.0f;
		}
		if (Input.GetKeyDown (spellKey)) {
			CastSpell ();
		}


		if (!Special_attack)
		{
						Attack (0,1,KeyCode.Space);
		}
		die ();
	}
	//Forces the val to be between a min and a max
	private int clamp(int min, int curr, int max)
	{
		if (min > curr)
			return min;
		else if (curr > max)
			return max;
		else
			return curr;
	}
	public void Get_Hit(int damage)
	{
		Health = clamp(0, Health - damage, maxHealth);
	}
	public void Use_Mana(int amount) {
		Mana = clamp(0, Mana - amount, maxMana);
	}

	void impact(int stun, double scaledDam)
	{
	   if (opponent != null && GetComponent<Animation>().IsPlaying(attack.name)&&!hit) 
		{
			if(GetComponent<Animation>()[attack.name].time>impactTime&&
			   GetComponent<Animation>()[attack.name].time < 0.9*GetComponent<Animation>()[attack.name].length)
			{
				SetCombatCountdown ();
				opponent.GetComponent<mob>().getHit((int)(damage*scaledDam));
				opponent.GetComponent<mob>().GetStun(stun);
				hit = true;
			}
		}
	}
	public void SetCombatCountdown() {
		countDown = escapeTime+2;
		CancelInvoke("CombatCountDown");
		InvokeRepeating("CombatCountDown",0,1);
	}

	public void Attack(int stun, double scaledDam,KeyCode key)
	{
		if(Input.GetKey(key)&&InRange()&opponent!=null&Health>0)
		{
			GetComponent<Animation>().Play(attack.name);
			ClickToMove.attack = true;
			if(opponent != null)
			{
				transform.LookAt(opponent.transform.position);
			}
		}
		if (GetComponent<Animation>()[attack.name].time > 0.9*GetComponent<Animation>()[attack.name].length)
		{
			ClickToMove.attack = false;
			hit = false;
		}
		impact (stun, scaledDam );
	}



	public void resetAttack()
	{
		ClickToMove.attack = false;
		hit = false;
		GetComponent<Animation>().Stop (attack.name);
	}


	bool InRange()
	{
		if (Vector3.Distance(opponent.transform.position, transform.position)<= range) 
		{
			return true;
		}
		return false;
	}

	public bool isDead()
	{
		//return true when char is dead
		if (Health ==0 ) 
		{
			return true;
		}
		return false;
	}

	void CombatCountDown()
	{
		countDown = countDown - 1;
		if (countDown == 0) 
		{
			CancelInvoke("CombatCountDown");
		}
	}

	void die()
	{
				if (isDead()&&!ended) 
				{
					if(!started)
					{
						GetComponent<Animation>().Play (dies.name);
						started = true;
						ClickToMove.dieing = true;
					}
					if(started&&!GetComponent<Animation>().IsPlaying(dies.name))
					{
				     Debug.Log("You Have Died");
					 ended = true;
					}
				}
	}

	void CastSpell() {
		if (Mana >= spellCost &&Time.time - lastSpellTime >= spellCooldown) {
			GameObject casted = (GameObject) Instantiate (fireBall, magicEmitter.transform.position, gameObject.transform.rotation);
			casted.GetComponent<Rigidbody> ().velocity = transform.forward*15;
			lastSpellTime = Time.time;
			Mana -= spellCost;
		}
	}







}
