using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private bool isGrounded = true;


    void Update() 
	{	
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, 0); //Set X and Z velocity to 0
 
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0, 0);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Jump(); //Manual jumping
			GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 700, 0), ForceMode.Force); 
			isGrounded = false;
        }
	}

    void Jump()
    {
        if (!isGrounded) {return;}
        isGrounded = false;
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		GetComponent<Rigidbody>().AddForce(new Vector3(0, 700, 0), ForceMode.Force); 
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "platform")
						isGrounded = true;    
	}

    /*void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, - Vector3.up, 1.0f);

        if (isGrounded)
        {
            Jump(); //Automatic jumping
        }
    }*/
       

}
