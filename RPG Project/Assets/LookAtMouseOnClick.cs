using UnityEngine;
using System.Collections;

public class LookAtMouseOnClick : MonoBehaviour {

	public Transform CharacterTransform;
	public float RotationSmoothingCoef = 0.01f;
	public bool isRotating = false;

	private Quaternion targetRotation;


	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			isRotating = false;
			return;
		}
		if(Input.GetMouseButton(1)) {
			var groundPlane = new Plane(Vector3.up, -CharacterTransform.position.y);
			var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float hitDistance;

			if (groundPlane.Raycast(mouseRay, out hitDistance))
			{
				var lookAtPosition = mouseRay.GetPoint(hitDistance);
				targetRotation = Quaternion.LookRotation(lookAtPosition - CharacterTransform.position, Vector3.up);
			}
			isRotating = true;
		}

	}

	void FixedUpdate()
	{
		if (isRotating) {
			var rotation = Quaternion.Lerp (CharacterTransform.rotation, targetRotation, RotationSmoothingCoef);
			CharacterTransform.rotation = rotation;
			if (rotation.Equals (targetRotation))
				isRotating = false;
		}
	}
}
