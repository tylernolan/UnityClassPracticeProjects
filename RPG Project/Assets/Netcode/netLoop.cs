using UnityEngine;
using System.Collections;

public class netLoop : MonoBehaviour {
	private GameObject player = null;
	public GameObject skeleton;
	public GameObject skeletonMage;
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
	/**
	0: Summon Basic Skeleton
	1: Summon Skeleton Mage
	2: Heal player 10
	3: Give player 10 mana
	**/
	public void executeCommand(string name, int command)
	{
		if (command == 0)
		{
			Instantiate(skeleton, player.transform.position, player.transform.rotation);
			Debug.Log(name+" has summoned a Skeleton!");
		}
		else if (command == 1)
		{
			Instantiate(skeletonMage, player.transform.position, player.transform.rotation);
			Debug.Log(name+" has summoned a Mage!");
		}
		else if (command == 2)
		{
			player.GetComponent<Fighter>().Get_Hit(-10); //hitting for negative values heals
			Debug.Log(name+" has healed the player!");
		}
		else if (command == 3)
		{
			player.GetComponent<Fighter>().Use_Mana(-10);
			Debug.Log(name+" has given the player mana!");
		}
		else if (command == 4)
		{
			GameObject enemy = GameObject.FindGameObjectsWithTag("Enemy")[0];
			enemy.GetComponent<mob>().smite();
			Debug.Log(name+" has smited an enemy!");
		}
	}
}
