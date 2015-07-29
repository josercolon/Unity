﻿using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 150;
	public GameObject projectile;
	public float projectileSpeed = 10;
	
	void Update(){
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <=0){
				Destroy(gameObject);
			}
		}
	}
}
