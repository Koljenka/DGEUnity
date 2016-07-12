﻿using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

	public Collider2D player;
	public int health = 10;
	public float speed = 1f;
	public float jump = 1f;



	private Rigidbody2D rb;
	private float direction = -1f;
	private bool up = false;



	void Start() {
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player);
		rb = GetComponent<Rigidbody2D>();

	}

	void FixedUpdate() {
		if (!up) {
			rb.velocity = new Vector2(speed * direction, 0f);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("ColUp")) {
			up = true;
			rb.velocity = new Vector2(0f, jump);
		} else if (col.CompareTag("Floor")) {
			if (rb.velocity.y <= 0) {
				up = false;
				direction *= -1;
			}
		} else if (col.CompareTag("Player")) {
			Debug.Log(Analytics.CustomEvent("gameOver", new Dictionary<string, object>{}));
			Destroy(col.gameObject);
		}
	}

	public void Damage(int damage) {
		health -= damage;
		if(health <= 0) {
			GetComponentInParent<Spawner>().Respawn();
			Destroy(gameObject);
		}
	}
}
