using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {

    [SerializeField]
    GameObject _bullet;

    [SerializeField]
    Transform bulletSpawn;

    public float bulletSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
	}


    void Fire()
    {
        var bullet = (GameObject)Instantiate(_bullet, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, 3.0f);
    }
}
