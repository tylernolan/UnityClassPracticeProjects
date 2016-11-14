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
	public bool Special_attack;
	//controls animations on death 
	public bool started;
	public bool ended;
	public float escapeTime = 10;
	public float countDown;


	// Use this for initialization
	void Start () 
	{
		Health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Special_attack)
		{
						Attack (0,1,KeyCode.Space);
		}
		die ();
	}
	public void Get_Hit(int damage)
	{
		Health -= damage;
		if (Health < 0) 
		{
			Health =0;
		}
	}

	void impact(int stun, double scaledDam)
	{
	   if (opponent != null && GetComponent<Animation>().IsPlaying(attack.name)&&!hit) 
		{
			if(GetComponent<Animation>()[attack.name].time>impactTime&&
			   GetComponent<Animation>()[attack.name].time < 0.9*GetComponent<Animation>()[attack.name].length)
			{
				countDown = escapeTime+2;
				CancelInvoke("CombatCountDown");
				InvokeRepeating("CombatCountDown",0,1);

				opponent.GetComponent<mob>().getHit((int)(damage*scaledDam));
				opponent.GetComponent<mob>().GetStun(stun);
				hit = true;
			}
		}
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








}
