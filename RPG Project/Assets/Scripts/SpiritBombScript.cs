using UnityEngine;
using System.Collections;

public class SpiritBombScript : MonoBehaviour {

	public Light light;
	public GameObject boss;
	public GameObject outerSphere;
	public void Grow()
	{
		//8 is the max :(
		if (light.intensity < 8)
		{
			light.intensity += .05f;
			outerSphere.transform.localScale += new Vector3(.04f, .04f, .04f);
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, .05f);
		}
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<mob>().health = 0;
		}
	}
}
