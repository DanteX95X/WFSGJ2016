﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 15;
    public int damage = 1;

    public GameObject ParentCharacter { get; set; }

    float counter = 0;

    private Transform particle_emmiter;
	private ParticleSystem hitMark;
	
    void Start()
    {	
		particle_emmiter = gameObject.transform.Find("HitMark");
		hitMark = particle_emmiter.GetComponent<ParticleSystem>();
    }
	
	protected void Update ()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
        DestroyBullet();
	}

    protected void DestroyBullet()
    {
        counter += Time.deltaTime;
        if (counter > 2)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject != ParentCharacter && (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Enemy"))
        {
            //collider.gameObject.GetComponent<IMortal>().Die();
            collider.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
            Debug.Log("Character has been shot");
        }

        if (collider.gameObject != ParentCharacter && collider.gameObject.tag != "Collectible" && collider.gameObject.tag != "AmmoCheckPoint")
		{
			// Unparent the particles from the bullet.
			hitMark.transform.parent = null;
			hitMark.Play();
			hitMark.Emit(20);	//count
			// Once the particles have finished, destroy the gameobject they are on.
			Destroy(hitMark.gameObject, hitMark.duration);
			
            Destroy(gameObject);
		}
    }
}
