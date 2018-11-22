using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;
    private bool isDead;
    public AudioClip explodeSound;
    public ParticleSystem hitFlash;

    void Start()
    {
        isDead = false;
    }

    public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

        if ( currentHealth <= 0 && !isDead )
        {
            gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(explodeSound, transform.position, 1f);
            Instantiate<ParticleSystem>(hitFlash, transform.position, transform.rotation);
        }

    }
}
