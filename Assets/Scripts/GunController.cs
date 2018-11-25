using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public bool isFiring;
	public Rigidbody bulletPrefab;
	public float bulletSpeed;
	public float fireRate;
	private float nextFire;
	public Transform gunEnd;
	[SerializeField]
	private ParticleSystem muzzleParticle;
	[SerializeField]
    public AudioClip gunFire;
    public AudioSource gunAudio;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring) {
            Fire();
		}
	}

    public void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            muzzleParticle.Play();
            gunAudio.clip = gunFire;
            gunAudio.Play();
            Rigidbody newBullet = Instantiate(bulletPrefab, gunEnd.position, gunEnd.rotation) as Rigidbody;
            newBullet.velocity = gunEnd.transform.forward * bulletSpeed;
        }
        
    }
}
