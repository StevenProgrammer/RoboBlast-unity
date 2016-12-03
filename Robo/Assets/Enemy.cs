using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class Enemy : MonoBehaviour {
	//what to chase?
	public Transform target;

	//how many times each WaitForSeconds we will update our path
	public float updateRate = 2f;

	private Seeker seeker;
	private Rigidbody2D rb;

	//calculated path
	public Path path;

	//AI's speed per sec
	public float speed = 300f;
	public ForceMode2D fmode;

	[HideInInspector]
	public bool PathIsEnded = false;

	//max distance from the Ai to a waypoint for it to continue to the next wayopint
	public float NextWaypointDistance = 3f;

	//waypoint we are currently moving towrds
	private int CurrentWaypoint = 0;

	void Start(){
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D>();

		if (target == null) {
			Debug.LogError("No player found");
			return;
		}
		//start a new path to the target position, return the result to the onpathcomplete method
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		StartCoroutine (UpdatePath ());
	}

	IEnumerator UpdatePath () {
		if (target == null) {
			//return false;
		}

		seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine (UpdatePath ());
	}


	public void OnPathComplete(Path p){
		Debug.LogError ("We got a pth. did it have an error? " + p.error);
		if (!p.error) {
			path = p;
			CurrentWaypoint = 0;
		}
	}

	void FixedUpdate () {
		if (target == null) {
			return;
		
	}

	if (path == null)
		return;

	if (CurrentWaypoint >= path.vectorPath.Count) {
		if (PathIsEnded)
				return;

			Debug.Log ("end of path reached.");
			PathIsEnded = true;
			return;
		
		}
		PathIsEnded = false;

		//direction to next waypoint
		Vector3 dir = (path.vectorPath [CurrentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		//Move the AI

		rb.AddForce (dir, fmode);
		float dist = Vector3.Distance (transform.position, path.vectorPath [CurrentWaypoint]);
		if (dist < NextWaypointDistance){
			CurrentWaypoint++;
			return;
		
		}

	}

}
