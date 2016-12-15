using UnityEngine;
using System.Collections;

public class BossCameraScript : MonoBehaviour {
	public Transform target;


	void Start(){
		transform.position = target.position;
		transform.rotation = target.rotation;
	}


}
