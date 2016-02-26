using UnityEngine;
using System.Collections;

public class SoldierSpawner : MonoBehaviour {
	public float totalSec;
	public float timer;
	public Rigidbody2D trooperToSpawn;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame ()
	void Update () {
		totalSec = Time.time - timer; // The total seconds that have passed since last spawn
		/* Time.time is Unity3D's built in tracking of the amount of time that has passed ingame.
		Because of the nature of the game thread, we can't pause a part of the game without pausing the
		entire game. Therefore, instead of waiting I instead calculate the difference in time to see if 
		enough time has passed since the last activation. 
		
		If game time is (Time.time) 330, and our function last ran at (timer) 324, then totalSec would equal 6.
		*/
		
		if (totalSec > 10) { // 10 = 10 Second delay
			Rigidbody2D clone;
			clone = Instantiate(trooperToSpawn, transform.position, transform.rotation) as Rigidbody2D;
			clone.velocity = transform.TransformDirection (Vector2.right * 3); // Give a slight velocity
			timer = Time.time; // Reset timer

		}

	}


}
