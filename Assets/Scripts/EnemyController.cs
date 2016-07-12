﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 1f;
	public float jump = 1f;


	private Rigidbody2D rb;
	private float direction = -1f;
	private bool up = false;


	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if(!up) {
			rb.velocity = new Vector2(speed * direction, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("ColUp")) {
			up = true;
			rb.velocity = new Vector2(0f, jump);
		} else if(col.CompareTag("Floor")) {
			if(rb.velocity.y <= 0) {
				up = false;
				direction *= -1;
			}
		}
	}
}