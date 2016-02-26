using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int Health = 100;
	public GameObject thisEnemyObject;

	[System.Serializable]
	public class EnemyStats
	{
		public int Health = 100;
	}
	Animator anim;
	public EnemyStats stats = new EnemyStats ();



	public int fallBoundary = -40;

	void Start () {
		thisEnemyObject = gameObject;

	}

	public void DamageEnemy(int damage){
		stats.Health -= damage;
		if (stats.Health <= 0) {

	 		Health = 0;
			//GameMaster.KillEnemy (this);
		}
	}

	// Called by Weapon.cs when damaging this enemy. It's set here so that we can 
	// be sure we are calling the correct game object.
	public void ShowDamage(){
		thisEnemyObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 0f, 0f);

	}

	void Update(){
		thisEnemyObject.GetComponent<SpriteRenderer> ().color = new Color (255f, 255f, 255f);
	}
		
}