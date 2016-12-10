using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class netLoop : MonoBehaviour {
	private GameObject player = null;
	public GameObject skeleton;
	public GameObject skeletonMage;
	public GameObject[] LogTextBoxes;
	public Queue<string> commandLog = new Queue<string>();
	// Use this for initialization
	void Start () {
		NetworkModel.sendConnRequest();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null)
		{
			player = GameObject.FindGameObjectsWithTag("Player")[0];
		}
		string data = NetworkModel.readFromSocket(false);
		if (data != null)
		{
			string[] netdata = data.Split(',');
			string name = netdata[0];
			int command = int.Parse(netdata[1]);
			executeCommand(name, command);
		}
	}
	public void setCommandLog(string name, string commandText)
	{
		string commandStr =  name + commandText;
		Debug.Log(commandStr);
		commandLog.Enqueue(commandStr);
		string[] arr = commandLog.ToArray();
		
		for (int i = 0; i < LogTextBoxes.Length & i < arr.Length; i++)
		{
			LogTextBoxes[i].GetComponent<Text>().text = arr[i];
		}
		if (LogTextBoxes.Length <= arr.Length)
		{
			commandLog.Dequeue();
		}
		
	}
	/**
	0: Summon Basic Skeleton
	1: Summon Skeleton Mage
	2: Heal player 10
	3: Give player 10 mana
	4: Smite an enemy
	**/
	public void executeCommand(string name, int command)
	{
		
		if (command == 0) {
			Instantiate (skeleton, player.transform.position, player.transform.rotation);
			setCommandLog (name, " Has summoned a Skeleton!");
		} else if (command == 1) {
			Instantiate (skeletonMage, player.transform.position, player.transform.rotation);
			setCommandLog (name, " Has summoned a Mage!");
		} else if (command == 2) {
			player.GetComponent<Fighter> ().Get_Hit (-10); //hitting for negative values heals
			setCommandLog (name, " Has healed the player!");
		} else if (command == 3) {
			player.GetComponent<Fighter> ().Use_Mana (-10);
			setCommandLog (name, " Has given the player mana!");
		} else if (command == 4) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			GameObject enemy = enemies [Random.Range(0,enemies.Length-1)];
			enemy.GetComponent<mob> ().smite ();
			setCommandLog (name, " Has smited an enemy!");
		} else if (command == 5) {
			setCommandLog (name, " says: " + Complimenter.getRandomCompliment ());
		}

	}
}
