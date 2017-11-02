using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health;

	private float overallHealth;

	ParticleSystem particles;

	private float sin;

	// Use this for initialization
	void Start () {
		
		overallHealth = health;	

		particles = GetComponentInChildren<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () {

		Movement();

	}

	private void Movement()
	{
		float x = Mathf.Sin(Time.time) * 0.1f;

		Vector3 move = new Vector3(transform.position.x + x, transform.position.y, transform.position.z );

		transform.position = move;
	}


	public void TakeDamage(float damage, Vector3 hitPosition){

		overallHealth -= damage;

		particles.transform.position = hitPosition;
		particles.Play();

		if(overallHealth <= 0){
			
			Destroy(gameObject);

		}

	}
}
