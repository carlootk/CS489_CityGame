using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;
    public AudioClip explodeSound;
    public AudioSource m_ExplosionAudio;
    public ParticleSystem hitFlash;

    void Start()
    {
        hitFlash = Instantiate(hitFlash).GetComponent<ParticleSystem>();
        hitFlash.gameObject.SetActive(false);
    }

    public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

        if ( currentHealth <= 0 )
        {
            OnDeath();
        }
        
    }

    private void OnDeath()
    { 

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        hitFlash.transform.position = transform.position;
        hitFlash.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        hitFlash.Play();

        // Play the tank explosion sound effect.
        AudioSource.PlayClipAtPoint(explodeSound, transform.position);

        // Turn the tank off.
        gameObject.SetActive(false);
        
    }

    
}
