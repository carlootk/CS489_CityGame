﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	public bool isFiring;
	public GameObject bulletPrefab;
	public float bulletSpeed;
	public float fireRate;
	private float nextFire;
	public Transform gunEnd;
	[SerializeField]
	private ParticleSystem muzzleParticle;
	[SerializeField]
	private AudioSource gunAudio;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isFiring && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			muzzleParticle.Play();
			gunAudio.Play();
			var newBullet = (GameObject)Instantiate(bulletPrefab, gunEnd.position, gunEnd.rotation);
			newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.up * bulletSpeed;
			Destroy(newBullet, 2.0f);
		}
	}
}
