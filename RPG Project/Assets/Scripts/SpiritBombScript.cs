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
			light.intensity += 1;
			outerSphere.transform.localScale += new Vector3(.25f, .25f, .25f);
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, 1);
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
