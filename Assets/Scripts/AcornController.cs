﻿using UnityEngine;
using System.Collections;

public class AcornController : MonoBehaviour {

	public float speed;


	private Rigidbody2D rb;

	void Start() {

		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(0f, -speed);
	}

	void Update() {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col != null) {
			if (col.CompareTag("Enemy")) {
			    EnemyController enemy = col.GetComponent<EnemyController>();
				if(enemy != null) {
					enemy.Damage(1);
					Destroy(gameObject);
				}

			}
		}
	}
}
