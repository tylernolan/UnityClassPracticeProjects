using UnityEngine;
using System.Collections;

public class mob : MonoBehaviour {

	public float speed;
	public float range;
	public float chaseRange;
	public Transform player;
	public CharacterController control;
	public AnimationClip run;
	public LevelSystem playerLevel;
	public AnimationClip idle;
	public GameObject smiteParticles;
	public int maxHealth;
	public int health;
	public int damage;
	public int exp_Value;
	public AnimationClip die;
	public AnimationClip attacks;
	public double ImpactTime = 0.36;
	private bool impacted = false;
	private Fighter opponent;
	private int stunTime;
	private float timeCounter = 0.0f;
	private float origSpeed;
	// Use this for initialization
	void Start () 
	{
		health = maxHealth;
		player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
		playerLevel = player.GetComponent<LevelSystem>();
		opponent = player.GetComponent<Fighter> ();
		origSpeed = speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (IsDead() == false) 
		{
			if (!inRange (chaseRange)) {
				GetComponent<Animation>().Play (idle.name);
				return;

			}
			if(stunTime<=0)
			{
			if (!inRange (range)) 
			{
					chase ();
			} else {
					//animation.CrossFade (idle.name);
			attack();
				if (GetComponent<Animation>()[attacks.name].time > 0.9*GetComponent<Animation>()[attacks.name].length)
				{
					impacted = false;
				}
			}
		   }
			else
			{
			}
		} else
		  staydead ();
	}
	public void smite()
	{
		health = 0;
		Instantiate(smiteParticles, transform.position, Quaternion.Euler(270, 0, 0));
	}

	public void TakeDamageOverTime(int damageAmount, float timeInterval) {
		timeCounter += Time.deltaTime;
		if (timeCounter >= timeInterval) {
			this.getHit (damageAmount);
			ResetTimer ();
		}
	}

	public void SlowDown(bool isSlowed, float factor) {
		if (isSlowed)
			speed = origSpeed * factor;
		else
			speed = origSpeed;
	}

	public void ResetTimer() {
		timeCounter = 0.0f;
	}

	public void GetStun(int seconds)
	{
		stunTime = seconds;
		InvokeRepeating ("stunCountDown",0f,1f);

	}

	bool inRange(float range)
	{
		if (Vector3.Distance (transform.position, player.position) < range) 
		{
		 return true;
		} else
		return false;
	}

	public void getHit(int damage)
	{
		health = health - damage;
		if (health < 0) 
		{
			health = 0;
		}
	}

	void chase()
	{
		transform.LookAt (player.position);
		//transform.position += transform.forward * speed * Time.deltaTime;
		control.SimpleMove (transform.forward * speed);
		GetComponent<Animation>().Play (run.name);
	}

	void OnMouseOver()
	{
		player.GetComponent<Fighter> ().opponent = gameObject;
		player.GetComponent<Fighter> ().SetCombatCountdown ();
	}

	bool IsDead()
	{
		if (health <= 0) 
		{
			return true;
		}
		return false;
	}

	void staydead()
	{
		if(GetComponent<Animation>()[die.name].time> GetComponent<Animation>()[die.name].length*0.9)
		{
			playerLevel.exp += exp_Value;
			Destroy(gameObject);
		}
		GetComponent<Animation>().Play (die.name);
	}

	void stunCountDown()
	{
		stunTime -= 1;
		if (stunTime == 0) 
		{
			CancelInvoke("stunCountDown");
		}
	}
	
	void attack()
	{
		GetComponent<Animation>().Play (attacks.name);

		if (GetComponent<Animation>() [attacks.name].time > ImpactTime&!impacted&&
		    GetComponent<Animation>()[attacks.name].time < 0.9*GetComponent<Animation>()[attacks.name].length) 
		{
			impacted =true;
			opponent.Get_Hit(damage);
		}
	}

















}


























