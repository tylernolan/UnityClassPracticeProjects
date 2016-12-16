using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	public float speed;
	public Vector3 position;
	public CharacterController CharControl;
	public AnimationClip run;
	public AnimationClip idle;
	public static bool attack = false;
	public static bool dieing = false;
	public GameObject particleEffect;
	private bool useParticle = true;
	public AudioClip[] footsteps;
	public AudioSource soundPlayer;
	private float footstepTimer = 0.0f;
	public float timeBetweenFootsteps = 0.25f;

	// Use this for initialization
	void Start () 
	{
		attack = false;
		dieing = false;
		position = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (!attack&&!dieing) 
		    {
			if (Input.GetMouseButton (0)) {
				//locate where the player clicked on the terain 

				Locate_Position ();
			} else {
				useParticle = true;

			}

			MoveToPosition ();
			} 
		else
		{

		}
	}

	//locate position of the user click
	void Locate_Position()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit, 1000))
		{
			if (hit.collider.tag == "Floor") {
				position = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
				if (useParticle) {
					Instantiate (particleEffect, position, Quaternion.identity);
					useParticle = false;
				}
			}
		}
	}

	//turn and move the player 
	void MoveToPosition()
	{ 
		//when game object is moving 
		if (Vector3.Distance (transform.position, position) > 1 && canMove()) {
			if (canMove ()) {
				footstepTimer += Time.deltaTime;
				if (footstepTimer >= timeBetweenFootsteps) {
					//Debug.Log ("Playing footstep");
					AudioClip soundToPlay = footsteps [Random.Range (0, footsteps.Length)];
					soundPlayer.clip = soundToPlay;
					soundPlayer.Play ();
					footstepTimer = 0.0f;
				}
				Quaternion newRotation = Quaternion.LookRotation (position - transform.position);
				newRotation.z = 0f;

				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
				//transform.position += transform.forward * speed * Time.deltaTime;
				CharControl.SimpleMove (transform.forward * speed);
						
				GetComponent<Animation> ().CrossFade (run.name);
			}
		} 
		else 
		{

			GetComponent<Animation>().CrossFade(idle.name);
		}
	}

	bool canMove() {
		Collider[] cols = Physics.OverlapSphere (transform.position, 1);
		foreach(Collider col in cols) {
			if (col.gameObject.tag == "Untagged") {
				Knockback ();
				return false;
			}
		}
		return true;
	}

	void Knockback() {
		CharControl.SimpleMove (transform.forward * -2);
		position = transform.position;
	}

}















