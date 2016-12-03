using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {



	// Update is called once per frame
	void Update () {
		//transform.LookAt
			Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position; //subtracting position of the player to mouse position
		difference.Normalize (); //normalizing vector. all the sum of the vector will be equal to 1
	
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		//transform.rotation - Quaternion.Euler (0f, 0f, rotZ + 90);
		//
	}
}
