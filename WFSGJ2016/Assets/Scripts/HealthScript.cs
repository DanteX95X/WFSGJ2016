using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
    public int health = 100;
    public Slider healthBar;
    public AudioClip deathClip;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        if (healthBar != null)
        {
            healthBar.value = health;
            healthBar.maxValue = health;
        }
        audio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (healthBar != null)
            healthBar.value = health;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        StartCoroutine("CDie");
    }
    IEnumerator CDie()
    {
        //Odpal animacje, odegraj dźwięk i odpal particle???
        if (audio != null && deathClip != null)
            audio.PlayOneShot(deathClip, 1f);
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }


}
