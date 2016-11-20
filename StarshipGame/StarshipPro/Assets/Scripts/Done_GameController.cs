using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public GameObject[] pickups;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float spawnWaitPickups;
	public float startWaitPickups;
	public float waveWait;
	public static int missileCount = 3;
	public static int maxNumberHitsBeforeDeath = 3;
	public int health = 3;
	public int scoreToWin;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private int score;
	
	void Start ()
	{
		maxNumberHitsBeforeDeath = health;
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		StartCoroutine (SpawnPickups ());

	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.G)) {
			maxNumberHitsBeforeDeath = 3;
			missileCount = 3;
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		if (score >= scoreToWin) {
			maxNumberHitsBeforeDeath = 3;
			missileCount = 3;
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		if (gameOver)
		{
			restartText.text = "Press 'R' for Restart";
			if (Input.GetKeyDown (KeyCode.R))
			{
				maxNumberHitsBeforeDeath = 3;
				missileCount = 3;
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if (gameOver)
					break;
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			if (gameOver)
				break;
			yield return new WaitForSeconds (waveWait);
		}
	}

	IEnumerator SpawnPickups ()
	{
		yield return new WaitForSeconds (startWaitPickups);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if (gameOver)
					break;
				GameObject pickup = pickups [Random.Range (0, pickups.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (pickup, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWaitPickups);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver)
				break;
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		GameObject.Find("Ship").GetComponent<Done_PlayerController>().KillPlayer ();
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void TakeDamage(){
			maxNumberHitsBeforeDeath--;
			if (maxNumberHitsBeforeDeath <= 0) {
				GameOver ();
			}

	}

	void OnGUI() {
		GUI.Label (new Rect (100, 100, 200, 100), "Missiles: " + missileCount);
		GUI.Label (new Rect (100, 150, 200, 100), "Health: " + maxNumberHitsBeforeDeath);

	}
}