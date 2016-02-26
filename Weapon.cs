using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public int Damage = 10;
	public int DarkScytheDamage = 50;
	public LayerMask toHit;
	public LayerMask toHitBackground;
	float timeToFire = 0;
	public float ScytheTimer;
	public float timer = 0;
	private Animator animator;

	public Player PlayerScript; // Get the player script to heal at checkpoints
	Transform firePoint;
	Transform firePointDirection;
	Transform firePointUpper;
	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint");
		firePointDirection = transform.FindChild("FireTarget");
		firePointUpper = transform.FindChild ("FirePointUpper");
		if (firePoint == null) {
			Debug.LogError ("No firepoint");
		}
		animator = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {

		// --- RAYCAST PLAYER POSITION FOR ACTIVATING DIALOG --- //
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 fireD = firePointDirection.right;
		Vector2 firePointUpperPosition = new Vector2 (firePointUpper.position.x, firePointUpper.position.y);
		RaycastHit2D constantHitPlayer = Physics2D.Raycast (firePointPosition, fireD, 1, toHitBackground); // This raycast shoots out short range constantly only to Background layer
		// --- Finish Raycast --- //


		if (constantHitPlayer.collider != null) { // All of the cutscenes will run like this to be triggered by ingame collider and raycast

			// ========= CUTSCENE SYSTEM - ACTIVATE CUTSCENES ========= //

			// ---- Cutscene 2 is activated! ---- //
			Cutscene2 cutscene2 = constantHitPlayer.collider.GetComponent<Cutscene2> (); // Attached to the Draconic History Wall #1
			if (cutscene2 != null) {
				
				cutscene2.Cutscene2IsPlaying = true;

			}

			Cutscene3 cutscene3 = constantHitPlayer.collider.GetComponent<Cutscene3> (); // Attached to the checkpoint crystal
			if (cutscene3 != null) {

				cutscene3.Cutscene3IsPlaying = true;

			}

			Cutscene4 cutscene4 = constantHitPlayer.collider.GetComponent<Cutscene4> (); // Attached to the checkpoint crystal
			if (cutscene4 != null) {

				cutscene4.Cutscene4IsPlaying = true;

			}
			Cutscene5 cutscene5 = constantHitPlayer.collider.GetComponent<Cutscene5> (); // Attached to the checkpoint crystal
			if (cutscene5 != null) {

				cutscene5.Cutscene5IsPlaying = true;

			}
			// ========= END ========= //

			// ========= PRESSURE PLATE SYSTEM - ACTIVATE OBJECTS AND TRAPS ========= //

			
			LightLampAutomatically LampLight1 = constantHitPlayer.collider.GetComponent<LightLampAutomatically> (); // Attached to the Draconic History Wall #1
			if (LampLight1 != null) {

				LampLight1.TurnOn = 1;

			}

			// ========= END ========= //

			// ========= CHECKPOINT SYSTEM - SAVE GAME DATA/HEAL ========= //

			// ---- Checkpoint 1 is activated! ---- //
	
			CheckPoint1 checkpoint1 = constantHitPlayer.collider.GetComponent<CheckPoint1> ();
			if (checkpoint1 != null) {
				if (checkpoint1.Checkpoint1Activated == false) {
					Debug.Log ("Checkpoint collider found with Script");
					checkpoint1.OnCheckpointActivate1 ();
					PlayerScript = gameObject.GetComponent<Player> ();
					PlayerScript.playerStats.Health = 80; // Health the player at a checkpoint
				}
			}

			Checkpoint2 checkpoint2 = constantHitPlayer.collider.GetComponent<Checkpoint2> ();
			if (checkpoint2 != null) {
				if (checkpoint2.Checkpoint2Activated == false) {
					Debug.Log ("Checkpoint collider found with Script");
					checkpoint2.OnCheckpointActivate2 ();
					PlayerScript = gameObject.GetComponent<Player> ();
					PlayerScript.playerStats.Health = 80; // Health the player at a checkpoint
				}
			}
			// ========= END ========= //

			// ========= MUSIC SYSTEM ========= //

			// ---- Checkpoint 1 is activated! ---- //


			// ========= END ========= //
		}

		// If it's single burst fire, call shoot()
		if (fireRate == 0) {
			if (Input.GetMouseButton (1)) {
				Shoot ();
			}
		}
		ScytheTimer = Time.time - timer; // Timer for the Dark Scythe
		if (ScytheTimer > 10) {
			if (Input.GetMouseButton (0)) {
				DarkScythe ();
				timer = Time.time;
				animator.SetBool ("Dark Attack", true);
			}
		}
		// If it's not single burst, check if holding down the button 
		// and also check if Time.time is bigger than timeToFire. This is
		// the 'place in time until next shot'
		// TODO: Need to change to 'hold mouse button down'
		else {
				if (Input.GetMouseButton (1) && Time.time > timeToFire) {
					timeToFire = Time.time + 1 / fireRate;
					Shoot ();
			}
		}
	}

	void DarkScythe(){
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 fireD = firePointDirection.right;
		Vector2 firePointUpperPosition = new Vector2 (firePointUpper.position.x, firePointUpper.position.y);
		if (firePoint.localScale.x < 0) {
			fireD = firePointDirection.right * -1;
		} 
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, fireD, 10, toHit);

		if (hit.collider != null) { // We hit something with the scythe
			Enemy enemy = hit.collider.GetComponent<Enemy> (); // Check to see if this guy has enemy script as a component
			if (enemy != null) {
				enemy.DamageEnemy (DarkScytheDamage);
			
				enemy.ShowDamage ();
				if (transform.localScale.x > 0) {
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.right * 3000);

				}
				if (transform.localScale.x < 0) {
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.up * 300);
					hit.collider.attachedRigidbody.AddForce (transform.right * -3000);

				}
			}
		}
	}


	void Shoot () {
		// Use 2D world coordinates to find the x and y values for the mouse, which will
		// be used to find its position on the screen.
		//Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		Vector2 fireD = firePointDirection.right;
		Vector2 firePointUpperPosition = new Vector2 (firePointUpper.position.x, firePointUpper.position.y);
		// RaycastHit creates a ray out of the position, in the direction of mouse position (By subtracting), and then sets the distance it will check
		// Change the distance to change the range of it
		// notTohit is the layer mask, which is used to set what the ray will strike in the scene
		//RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition - firePointPosition, 10, toHit);
		if (firePoint.localScale.x < 0) {
			fireD = firePointDirection.right * -1;
			//fireDUpper = firePointUpper.right * -1;
		} 
		Debug.DrawRay (firePointPosition, fireD, Color.green);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, fireD, 10, toHit);
		RaycastHit2D hitUpper = Physics2D.Raycast (firePointUpperPosition, fireD, 10, toHit);
		RaycastHit2D hitBackground = Physics2D.Raycast (firePointPosition, fireD, 10, toHitBackground); // This only casts with firebreath (RMB)
		RaycastHit2D hitUpperBackground = Physics2D.Raycast (firePointUpperPosition, fireD, 10, toHitBackground); // This only casts with firebreath (RMB)
		if (hit.collider != null) {
			
			Enemy enemy = hit.collider.GetComponent<Enemy> ();
			if (enemy != null) {
				enemy.DamageEnemy (Damage);
	//			yield return new WaitForSeconds(1);
				Debug.Log("We hit " + hit.collider.name);
				enemy.ShowDamage (); // Call the function that turns the enemy red!
				if (transform.localScale.x > 0) {
					hit.collider.attachedRigidbody.AddForce(transform.right * 30);
				}
				if (transform.localScale.x < 0) {
					hit.collider.attachedRigidbody.AddForce(transform.right * -30);
				}
			}

		}
		if (hitUpper.collider != null) {

			Enemy enemy = hitUpper.collider.GetComponent<Enemy> ();
			if (enemy != null) {
				enemy.DamageEnemy (Damage);
				//			yield return new WaitForSeconds(1);
				Debug.Log("We hit " + hitUpper.collider.name);
			}

		}
		if (hitBackground.collider != null) {
			ActivationPuzzle1 ActivationPuzzle1 = hitBackground.collider.GetComponent<ActivationPuzzle1> ();	
			if (ActivationPuzzle1 != null) {
				ActivationPuzzle1.ActivatePuzzle ();
				Debug.Log ("RaycastHit toHit ActivationPuzzle1 activater");
			}
		}

		if(hitUpperBackground.collider != null) {
			ActivationPuzzle1 ActivationPuzzle1 = hitUpperBackground.collider.GetComponent<ActivationPuzzle1> ();	
			if (ActivationPuzzle1 != null) {
				ActivationPuzzle1.ActivatePuzzle ();
				Debug.Log ("RaycastHit toHit ActivationPuzzle1 activater");
			}
		}

	}
}

