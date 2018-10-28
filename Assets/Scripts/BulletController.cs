using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public int bulletDamage;
    public float hitForce = 100f;
	public AudioClip hitSound;
	public AudioClip explodeSound;
	public ParticleSystem hitFlash;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
		AudioSource.PlayClipAtPoint(hitSound, other.transform.position, 1f);
        EnemyHealth health = other.GetComponent<EnemyHealth>();
		
        if (health != null)
        {
            health.Damage(bulletDamage);
			
			
            if (health.currentHealth == 0)
            {
				AudioSource.PlayClipAtPoint(explodeSound, other.transform.position, 1f);
                Destroy(health.gameObject);				
				Instantiate<ParticleSystem>(hitFlash, other.transform.position, other.transform.rotation);
            }
        }
        if (other.GetComponent<Rigidbody>() != null)
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * hitForce);
        }

        Destroy(gameObject);
    }

}
