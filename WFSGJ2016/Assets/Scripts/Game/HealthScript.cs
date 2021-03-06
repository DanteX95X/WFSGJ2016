﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Enemy;

public class HealthScript : MonoBehaviour
{
    public int health = 100;
    public bool deathWhenNoHealth = true;
    public Slider healthBar;
    public AudioClip deathClip;
    public ParticleSystem particle;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (healthBar != null)
            healthBar.value = health;
        if (dmg > 0 && particle != null && !particle.isPlaying)
            particle.Play();

        if (health <= 0 && deathWhenNoHealth)
            Die();
    }

	public void AddHealth(int healthValue)
	{
		health += healthValue;
		if (health > 100)
			health = 100;

	}

    public void Die()
    {
        StartCoroutine("CDie");
    }
    IEnumerator CDie()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
            foreach (SpriteRenderer child in transform.GetComponentsInChildren<SpriteRenderer>())
                child.enabled = false;
        }
        
        if (audioSource != null && deathClip != null)
            audioSource.PlayOneShot(deathClip, 1f);
        if (gameObject.tag == "Enemy")
        {
            if (GameObject.Find("GameModeControler")!=null)
            GameObject.Find("GameModeControler").GetComponent<GameModeScript>().intCounter += 1;
        }
        yield return new WaitForSeconds(0.5f);

        
        Destroy(gameObject);
        if (GetComponent<Enemy>() != null)
            GetComponent<Enemy>().DropCollectible();
    }


}