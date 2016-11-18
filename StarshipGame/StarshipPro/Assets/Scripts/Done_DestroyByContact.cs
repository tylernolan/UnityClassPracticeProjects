using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public int hitsToKill = 1;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyShot" || other.tag == "Missile" || other.name.Contains("Pickup"))
		{
			return;
		}
		hitsToKill--;
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.TakeDamage();
			if(hitsToKill <= 0)
				Destroy (gameObject);
			return;
		}

		if (other.tag == "Shield") {
			Instantiate(explosion, transform.position, transform.rotation);
			if (hitsToKill <= 0) {
				Destroy (gameObject);
				gameController.AddScore (scoreValue);
			}
			return;
		}
		gameController.AddScore(scoreValue);
		if (hitsToKill <= 0) {
			Destroy (gameObject);
			gameController.AddScore (scoreValue);
		}
		Destroy (other.gameObject);
	}
}