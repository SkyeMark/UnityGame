using UnityEngine;
using System.Collections;

public class SoldierSpawner : MonoBehaviour {
	public float totalSec;
	public float timer;
	public Rigidbody2D trooperToSpawn;
	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {


		totalSec = Time.time - timer;
		if (totalSec > 10) {
			Rigidbody2D clone;
			clone = Instantiate(trooperToSpawn, transform.position, transform.rotation) as Rigidbody2D;
			clone.velocity = transform.TransformDirection (Vector2.right * 3);
			timer = Time.time;

		}


		// Reset timer

	}


}