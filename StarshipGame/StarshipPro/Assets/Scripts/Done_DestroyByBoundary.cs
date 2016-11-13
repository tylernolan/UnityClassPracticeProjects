using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		if (other.tag != "Missile")
			Destroy (other.gameObject);
		else
			other.gameObject.GetComponent<MissleScript> ().Explode ();
	}
}