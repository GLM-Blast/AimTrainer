using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    [SerializeField]
    GameObject _bullet;

    [SerializeField]
    Transform bulletSpawn;

	[SerializeField] 
	GameObject particles;

	ParticleSystem hitParticles;

    public float bulletSpeed = 10.0f;

	Animation gunFireAnim;


	public AudioClip gunShotSound;
	public float volume;


	// Use this for initialization
	void Start () {

		gunFireAnim = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
	}


	void Fire(){
		GunShotSound();
		gunFireAnim.Play();

		RaycastHit hit;

		Transform cam = Camera.main.transform;

		if(Physics.Raycast(cam.position, transform.forward, out hit)){

			if(hit.transform.tag != "Enemy"){
				HitParticlesAnimate(hit.point);
			}

			if(hit.transform.tag == "Enemy"){
				Debug.Log("Hit an enemy!");

				Enemy enemy = hit.collider.GetComponent<Enemy>();

				enemy.TakeDamage(5, hit.point);

			}
		}	
	}


	// -- -- -- ALLOWS GUNSHOT SOUNDS TO OVERLAP -- -- -- \\

	void GunShotSound()
	{
		float timer = 0.0f;
		timer = timer + Time.time;

		AudioSource gunShot;

		gunShot = gameObject.AddComponent<AudioSource>();
		gunShot.clip = gunShotSound;
		gunShot.volume = volume;
		gunShot.Play();

		Destroy(gunShot, 3.5f);

	}



	void HitParticlesAnimate(Vector3 hitPoint)
	{
		GameObject p = Instantiate(particles, hitPoint, Quaternion.identity)as GameObject;

		hitParticles = p.GetComponent<ParticleSystem>();
		hitParticles.Play();

		Destroy(p, 1.0f);

	}
    
}
