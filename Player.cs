using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Health = 80;
	public int Level = 1; // TODO: change level parameter to be loaded from save
	public int Experience = 0; // TODO: Change experience to be loaded from save
	// Health runes need to be set in the inspector in unity
	public GameObject PlayerObject; // The player object for loading games
	public GameObject PortraitD; // Get object for portrait to avoid showing it initially
	public GameObject HealthRune1;
	public GameObject HealthRune2;
	public GameObject HealthRune3;
	public GameObject HealthRune4;
	public GameObject HealthRune5;
	public GameObject HealthRune6;
	public GameObject HealthRune7;
	public GameObject HealthRune8;
	public float timer = 0;
	public float totalSec = 0;
	private bool collisionFlag = false;
	private Animator animator;

	[System.Serializable]
	public class PlayerStats
	{
		public int Health = 80;
	}

	public PlayerStats playerStats = new PlayerStats ();

	public int fallBoundary = -40;

	void Update (){
		if (transform.position.y <= fallBoundary) {
			DamagePlayer (999999);
		}

		if (transform.position.x >= PlayerPrefs.GetFloat ("PlayerProgressX") -1 && transform.position.x <= PlayerPrefs.GetFloat ("PlayerProgressX") +1) {
			playerStats.Health = 80;
			Debug.Log ("Health set to 80!!!!!!!!");
		}
		SetHealthBar ();

			
	}
		
	public void DamagePlayer(int damage){
		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			GameMaster.KillPlayer (this);
		}
	}
		public void SetHealthBar(){
		// If the health stat is X, set health bar status
		if (playerStats.Health == 80) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = true;;
		}
		if (playerStats.Health == 70) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 60) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 50) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 40) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 30) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 20) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 10) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = true;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
		if (playerStats.Health == 0) {
			HealthRune1.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune2.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune3.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune4.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune5.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune6.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune7.GetComponent<SpriteRenderer> ().enabled = false;
			HealthRune8.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void Start () {
		PortraitD.GetComponent<SpriteRenderer> ().sprite = null;
		playerStats.Health = 80;
		animator = GetComponent<Animator>();
		transform.position = new Vector2 (PlayerPrefs.GetFloat ("PlayerProgressX"), PlayerPrefs.GetFloat ("PlayerProgressY"));
		animator.SetBool ("WakeUp", true); // Set value to true on start due to animator
	}
		
	void OnCollisionEnter2D(Collision2D collider){
		
		if (collider.gameObject.tag == "Enemy" && collisionFlag == true) {
			totalSec = Time.time - timer;
			if (totalSec > 2) {
				collisionFlag = false;
			}
		}
		if (collider.gameObject.tag == "Enemy" && collisionFlag == false) {
			DamagePlayer (10);
			Debug.Log (playerStats.Health);
			timer = Time.time;
			} 
			
		// Stop collision from triggering multiple times in one collide
		if (collider.gameObject.tag == "Enemy") {
			collisionFlag = true;
			// Delay 3 or so seconds before resetting the collision flag to false


			}
			

		}
	public void startControls(){
		animator.SetBool ("StandUp", true);
	}


}
