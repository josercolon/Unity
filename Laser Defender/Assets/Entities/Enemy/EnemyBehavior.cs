﻿using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 150;
	public GameObject projectile;
	public float projectileSpeed = 5.0f;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	public AudioClip eLaser;
	public AudioClip eDies;

	private ScoreKeeper scoreKeeper;

	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
		Fire ();
		}
	}

	void Fire(){
		GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint (eLaser, transform.position);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <=0){
				Die ();
			}
		}
	}
	void Die(){
		AudioSource.PlayClipAtPoint (eDies, transform.position);
		scoreKeeper.Score(scoreValue);
		Destroy(gameObject);
	}
}
